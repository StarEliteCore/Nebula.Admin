using Destiny.Core.Flow.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IdentityServer.Service.Consent
{
    public interface IConsentService:IScopedDependency
    {
        Task<ConsentViewModel> BuildViewModelAsync(string returnUrl, ConsentInputModel model = null);
        Task<ProcessConsentResult> ProcessConsent(ConsentInputModel model);
    }
}
