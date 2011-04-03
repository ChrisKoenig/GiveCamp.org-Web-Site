using GiveCamp.Funding.Data;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.GenericContent.Configuration;

namespace GiveCamp.Funding.Configuration
{
    /// <summary>
    /// The config class used by FundingModule
    /// </summary>
    public class FundingConfig : ContentModuleConfigBase
    {
        /// <summary>
        /// Initializes the default providers.
        /// </summary>
        /// <param name="providers"></param>
        protected override void InitializeDefaultProviders(ConfigElementDictionary<string, DataProviderSettings> providers)
        {
            providers.Add(new DataProviderSettings(this.Providers)
            {
                Name = "OpenAccessDataProvider",
                Description = "A provider that stores funding requests in a database using OpenAccess ORM.",
                ProviderType = typeof(OpenAccessFundingDataProvider)
            });
        }

        /// <summary>
        /// Initializes the default views.
        /// </summary>
        /// <param name="contentViewControls"></param>
        protected override void InitializeDefaultViews(ConfigElementDictionary<string, Telerik.Sitefinity.Web.UI.ContentUI.Config.ContentViewControlElement> contentViewControls)
        {
        }
    }
}