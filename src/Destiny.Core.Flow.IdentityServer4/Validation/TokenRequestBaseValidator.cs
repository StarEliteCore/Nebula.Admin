using IdentityModel;
using IdentityServer4;
using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IdentityServer.Validation
{
    public class TokenRequestBaseValidator : ITokenRequestValidator
    {
        private readonly IdentityServerOptions _options;
        private readonly IAuthorizationCodeStore _authorizationCodeStore;
        private readonly ExtensionGrantValidator _extensionGrantValidator;
        private readonly ICustomTokenRequestValidator _customRequestValidator;
        private readonly IResourceValidator _resourceValidator;
        private readonly IResourceStore _resourceStore;
        private readonly ITokenValidator _tokenValidator;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IEventService _events;
        private readonly IResourceOwnerPasswordValidator _resourceOwnerValidator;
        private readonly IProfileService _profile;
        private readonly IDeviceCodeValidator _deviceCodeValidator;
        private readonly ISystemClock _clock;
        private readonly ILogger _logger;
        private ValidatedTokenRequest _validatedRequest;

        public TokenRequestBaseValidator(IdentityServerOptions options, IAuthorizationCodeStore authorizationCodeStore, ExtensionGrantValidator extensionGrantValidator, ICustomTokenRequestValidator customRequestValidator, IResourceValidator resourceValidator, IResourceStore resourceStore, ITokenValidator tokenValidator, IRefreshTokenService refreshTokenService, IEventService events, IResourceOwnerPasswordValidator resourceOwnerValidator, IProfileService profile, IDeviceCodeValidator deviceCodeValidator, ISystemClock clock, ILogger logger, ValidatedTokenRequest validatedRequest)
        {
            _options = options;
            _authorizationCodeStore = authorizationCodeStore;
            _extensionGrantValidator = extensionGrantValidator;
            _customRequestValidator = customRequestValidator;
            _resourceValidator = resourceValidator;
            _resourceStore = resourceStore;
            _tokenValidator = tokenValidator;
            _refreshTokenService = refreshTokenService;
            _events = events;
            _resourceOwnerValidator = resourceOwnerValidator;
            _profile = profile;
            _deviceCodeValidator = deviceCodeValidator;
            _clock = clock;
            _logger = logger;
            _validatedRequest = validatedRequest;
        }

        public async Task<TokenRequestValidationResult> ValidateRequestAsync(NameValueCollection parameters, ClientSecretValidationResult clientValidationResult)
        {
            var grantType = parameters.Get(OidcConstants.TokenRequest.GrantType);
            _validatedRequest = new ValidatedTokenRequest
            {
                Raw = parameters ?? throw new ArgumentNullException(nameof(parameters)),
                Options = _options
            };

            switch (grantType)
            {
                case OidcConstants.GrantTypes.AuthorizationCode:
                    return await RunValidationAsync(ValidateAuthorizationCodeRequestAsync, parameters);
                case OidcConstants.GrantTypes.ClientCredentials:
                    return await RunValidationAsync(ValidateClientCredentialsRequestAsync, parameters);
                case OidcConstants.GrantTypes.Password:
                    return await RunValidationAsync(ValidateResourceOwnerCredentialRequestAsync, parameters);
                case OidcConstants.GrantTypes.RefreshToken:
                    return await RunValidationAsync(ValidateRefreshTokenRequestAsync, parameters);
                case OidcConstants.GrantTypes.DeviceCode:
                    return await RunValidationAsync(ValidateDeviceCodeRequestAsync, parameters);
                default:
                    return await RunValidationAsync(ValidateExtensionGrantRequestAsync, parameters);
            }

        }
        private async Task<TokenRequestValidationResult> ValidateExtensionGrantRequestAsync(NameValueCollection parameters)
        {
            _logger.LogDebug("Start validation of custom grant token request");

            /////////////////////////////////////////////
            // check if client is allowed to use grant type
            /////////////////////////////////////////////
            if (!_validatedRequest.Client.AllowedGrantTypes.Contains(_validatedRequest.GrantType))
            {
                LogError("Client does not have the custom grant type in the allowed list, therefore requested grant is not allowed", new { clientId = _validatedRequest.Client.ClientId });
                return Invalid(OidcConstants.TokenErrors.UnsupportedGrantType);
            }

            /////////////////////////////////////////////
            // check if a validator is registered for the grant type
            /////////////////////////////////////////////
            if (!_extensionGrantValidator.GetAvailableGrantTypes().Contains(_validatedRequest.GrantType, StringComparer.Ordinal))
            {
                LogError("No validator is registered for the grant type", new { grantType = _validatedRequest.GrantType });
                return Invalid(OidcConstants.TokenErrors.UnsupportedGrantType);
            }

            /////////////////////////////////////////////
            // check if client is allowed to request scopes
            /////////////////////////////////////////////
            if (!await ValidateRequestedScopesAsync(parameters))
            {
                return Invalid(OidcConstants.TokenErrors.InvalidScope);
            }

            /////////////////////////////////////////////
            // validate custom grant type
            /////////////////////////////////////////////
            var result = await _extensionGrantValidator.ValidateAsync(_validatedRequest);

            if (result == null)
            {
                LogError("Invalid extension grant");
                return Invalid(OidcConstants.TokenErrors.InvalidGrant);
            }

            if (result.IsError)
            {
                if (result.Error.IsPresent())
                {
                    LogError("Invalid extension grant", new { error = result.Error });
                    return Invalid(result.Error, result.ErrorDescription, result.CustomResponse);
                }
                else
                {
                    LogError("Invalid extension grant");
                    return Invalid(OidcConstants.TokenErrors.InvalidGrant, customResponse: result.CustomResponse);
                }
            }

            if (result.Subject != null)
            {
                /////////////////////////////////////////////
                // make sure user is enabled
                /////////////////////////////////////////////
                var isActiveCtx = new IsActiveContext(
                    result.Subject,
                    _validatedRequest.Client,
                    IdentityServerConstants.ProfileIsActiveCallers.ExtensionGrantValidation);

                await _profile.IsActiveAsync(isActiveCtx);

                if (isActiveCtx.IsActive == false)
                {
                    // todo: raise event?

                    LogError("User has been disabled", new { subjectId = result.Subject.GetSubjectId() });
                    return Invalid(OidcConstants.TokenErrors.InvalidGrant);
                }

                _validatedRequest.Subject = result.Subject;
            }

            _logger.LogDebug("Validation of extension grant token request success");
            return Valid(result.CustomResponse);
        }
        private async Task<TokenRequestValidationResult> RunValidationAsync(Func<NameValueCollection, Task<TokenRequestValidationResult>> validationFunc, NameValueCollection parameters)
        {
            // run standard validation
            var result = await validationFunc(parameters);
            if (result.IsError)
            {
                return result;
            }

            // run custom validation
            _logger.LogTrace("Calling into custom request validator: {type}", _customRequestValidator.GetType().FullName);

            var customValidationContext = new CustomTokenRequestValidationContext { Result = result };
            await _customRequestValidator.ValidateAsync(customValidationContext);

            if (customValidationContext.Result.IsError)
            {
                if (customValidationContext.Result.Error.IsPresent())
                {
                    LogError("Custom token request validator", new { error = customValidationContext.Result.Error });
                }
                else
                {
                    LogError("Custom token request validator error");
                }

                return customValidationContext.Result;
            }

            LogSuccess();
            return customValidationContext.Result;
        }
        private void LogSuccess()
        {
            LogWithRequestDetails(LogLevel.Information, "Token request validation success");
        }
    }
}
