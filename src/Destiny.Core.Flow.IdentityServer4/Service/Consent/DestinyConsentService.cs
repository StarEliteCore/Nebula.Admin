//using Destiny.Core.Flow.IdentityServer.IdentityServerFour;
//using IdentityServer4.Models;
//using IdentityServer4.Services;
//using IdentityServer4.Stores;
//using IdentityServer4.Validation;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Destiny.Core.Flow.IdentityServer.Service.Consent
//{
//    public class DestinyConsentService: IDestinyConsentService
//    {
//        private readonly IClientStore _clientStore;
//        private readonly IResourceStore _resourceStore;
//        private readonly IIdentityServerInteractionService _interaction;
//        //private readonly ILogger _logger;

//        public DestinyConsentService(
//            IIdentityServerInteractionService interaction,
//            IClientStore clientStore,
//            IResourceStore resourceStore
//            /*ILogger logger*/)
//        {
//            _interaction = interaction;
//            _clientStore = clientStore;
//            _resourceStore = resourceStore;
//            //_logger = logger;
//        }

//        public async Task<ProcessConsentResult> ProcessConsent(ConsentInputModel model)
//        {
//            var result = new ProcessConsentResult();

//            // validate return url is still valid
//            var request = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
//            if (request == null) return result;

//            ConsentResponse grantedConsent = null;

//            // user clicked 'no' - send back the standard 'access_denied' response
//            if (model?.Button == "no")
//            {
//                grantedConsent = new ConsentResponse { Error = AuthorizationError.AccessDenied };

//                // emit event
//                await _events.RaiseAsync(new ConsentDeniedEvent(User.GetSubjectId(), request.Client.ClientId, request.ValidatedResources.RawScopeValues));
//            }
//            // user clicked 'yes' - validate the data
//            else if (model?.Button == "yes")
//            {
//                // if the user consented to some scope, build the response model
//                if (model.ScopesConsented != null && model.ScopesConsented.Any())
//                {
//                    var scopes = model.ScopesConsented;
//                    if (ConsentOptions.EnableOfflineAccess == false)
//                    {
//                        scopes = scopes.Where(x => x != IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess);
//                    }

//                    grantedConsent = new ConsentResponse
//                    {
//                        RememberConsent = model.RememberConsent,
//                        ScopesValuesConsented = scopes.ToArray(),
//                        Description = model.Description
//                    };

//                    // emit event
//                    await _events.RaiseAsync(new ConsentGrantedEvent(User.GetSubjectId(), request.Client.ClientId, request.ValidatedResources.RawScopeValues, grantedConsent.ScopesValuesConsented, grantedConsent.RememberConsent));
//                }
//                else
//                {
//                    result.ValidationError = ConsentOptions.MustChooseOneErrorMessage;
//                }
//            }
//            else
//            {
//                result.ValidationError = ConsentOptions.InvalidSelectionErrorMessage;
//            }

//            if (grantedConsent != null)
//            {
//                // communicate outcome of consent back to identityserver
//                await _interaction.GrantConsentAsync(request, grantedConsent);

//                // indicate that's it ok to redirect back to authorization endpoint
//                result.RedirectUri = model.ReturnUrl;
//                result.Client = request.Client;
//            }
//            else
//            {
//                // we need to redisplay the consent UI
//                result.ViewModel = await BuildViewModelAsync(model.ReturnUrl, model);
//            }

//            return result;
//        }

//        public async Task<ConsentViewModel> BuildViewModelAsync(string returnUrl, ConsentInputModel model = null)
//        {
//            var request = await _interaction.GetAuthorizationContextAsync(returnUrl);
//            if (request != null)
//            {
//                return CreateConsentViewModel(model, returnUrl, request);
//            }
//            else
//            {
//                Console.WriteLine("No consent request matching request: {0}");
//            }
//            return null;
//        }

//        private ConsentViewModel CreateConsentViewModel(
//            ConsentInputModel model, string returnUrl,
//            AuthorizationRequest request)
//        {
//            var vm = new ConsentViewModel
//            {
//                RememberConsent = model?.RememberConsent ?? true,
//                ScopesConsented = model?.ScopesConsented ?? Enumerable.Empty<string>(),
//                Description = model?.Description,

//                ReturnUrl = returnUrl,

//                ClientName = request.Client.ClientName ?? request.Client.ClientId,
//                ClientUrl = request.Client.ClientUri,
//                ClientLogoUrl = request.Client.LogoUri,
//                AllowRememberConsent = request.Client.AllowRememberConsent
//            };

//            vm.IdentityScopes = request.ValidatedResources.Resources.IdentityResources.Select(x => CreateScopeViewModel(x, vm.ScopesConsented.Contains(x.Name) || model == null)).ToArray();

//            var apiScopes = new List<ScopeViewModel>();
//            foreach (var parsedScope in request.ValidatedResources.ParsedScopes)
//            {
//                var apiScope = request.ValidatedResources.Resources.FindApiScope(parsedScope.ParsedName);
//                if (apiScope != null)
//                {
//                    var scopeVm = CreateScopeViewModel(parsedScope, apiScope, vm.ScopesConsented.Contains(parsedScope.RawValue) || model == null);
//                    apiScopes.Add(scopeVm);
//                }
//            }
//            if (ConsentOptions.EnableOfflineAccess && request.ValidatedResources.Resources.OfflineAccess)
//            {
//                apiScopes.Add(GetOfflineAccessScope(vm.ScopesConsented.Contains(IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess) || model == null));
//            }
//            vm.ApiScopes = apiScopes;

//            return vm;
//        }

//        private ScopeViewModel CreateScopeViewModel(IdentityResource identity, bool check)
//        {
//            return new ScopeViewModel
//            {
//                Value = identity.Name,
//                DisplayName = identity.DisplayName ?? identity.Name,
//                Description = identity.Description,
//                Emphasize = identity.Emphasize,
//                Required = identity.Required,
//                Checked = check || identity.Required
//            };
//        }

//        private ScopeViewModel CreateScopeViewModel(ParsedScopeValue parsedScopeValue, ApiScope apiScope, bool check)
//        {
//            var displayName = apiScope.DisplayName ?? apiScope.Name;
//            if (!String.IsNullOrWhiteSpace(parsedScopeValue.ParsedParameter))
//            {
//                displayName += ":" + parsedScopeValue.ParsedParameter;
//            }

//            return new ScopeViewModel
//            {
//                Value = parsedScopeValue.RawValue,
//                DisplayName = displayName,
//                Description = apiScope.Description,
//                Emphasize = apiScope.Emphasize,
//                Required = apiScope.Required,
//                Checked = check || apiScope.Required
//            };
//        }

//        private ScopeViewModel GetOfflineAccessScope(bool check)
//        {
//            return new ScopeViewModel
//            {
//                Value = IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess,
//                DisplayName = ConsentOptions.OfflineAccessDisplayName,
//                Description = ConsentOptions.OfflineAccessDescription,
//                Emphasize = true,
//                Checked = check
//            };
//        }



//    }
//}
