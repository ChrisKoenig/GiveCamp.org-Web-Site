using System;
using System.Linq;
using GiveCamp.Funding.Configuration;
using GiveCamp.Funding.Localization;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.GenericContent;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Services;

namespace GiveCamp.Funding
{
    /// <summary>
    /// A content-based module used for managing user-submitted job applications.
    /// </summary>
    public class FundingModule : ContentModuleBase
    {
        public const string ModuleName = "GiveCampFunding";

        /// <summary>
        /// Gets the CLR types of all data managers provided by this module.
        /// </summary>
        /// <value>An array of <see cref="T:System.Type"/> objects.</value>
        public override Type[] Managers
        {
            get
            {
                return new[] { typeof(FundingManager) };
            }
        }

        /// <summary>
        /// Gets the landing page id for each module inherit from <see cref="SecuredModuleBase"/> class.
        /// </summary>
        /// <value>The landing page id.</value>
        public override Guid LandingPageId
        {
            get
            {
                return FundingModule.HomePageId;
            }
        }

        /// <summary>
        /// Initializes the service with specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public override void Initialize(ModuleSettings settings)
        {
            base.Initialize(settings);
            Config.RegisterSection<FundingConfig>();
            Res.RegisterResource<FundingResources>();
        }

        /// <summary>
        /// Installs this module in Sitefinity system.
        /// </summary>
        /// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
        public override void Install(SiteInitializer initializer)
        {
            base.Install(initializer);
            // do something here
        }

        /// <summary>
        /// Upgrades this module from the specified version.
        /// </summary>
        /// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
        /// <param name="upgradeFrom">The version this module us upgrading from.</param>
        public override void Upgrade(SiteInitializer initializer, Version upgradeFrom)
        {
        }

        /// <summary>
        /// Gets the module config.
        /// </summary>
        /// <returns></returns>
        protected override ConfigSection GetModuleConfig()
        {
            return Config.Get<FundingConfig>();
        }

        /// <summary>
        /// Installs the pages.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        protected override void InstallPages(SiteInitializer initializer)
        {
            var moduleNode = initializer.PageManager.GetPageNode(SiteInitializer.ModulesNodeId);
            var pageManager = initializer.PageManager;

            var fundingRequestNode = pageManager.GetPageNodes().Where(p => p.Id == FundingModule.HomePageId).SingleOrDefault();
            if (fundingRequestNode == null)
            {
                fundingRequestNode = initializer.CreatePageNode(FundingModule.HomePageId, moduleNode);

                fundingRequestNode.Name = FundingModule.ModuleName;
                fundingRequestNode.ShowInNavigation = true;
                fundingRequestNode.Attributes["ModuleName"] = FundingModule.ModuleName;
                fundingRequestNode.Title = FundingModule.ModuleName;
                fundingRequestNode.UrlName = FundingModule.ModuleName;
            }

            // create the subpage
            var subPage = pageManager.GetPageNodes().Where(p => p.Id == FundingModule.ChildPageId).SingleOrDefault();
            if (subPage == null)
            {
                var pageInfo = new PageDataElement()
                {
                    PageId = FundingModule.ChildPageId,
                    Name = "FundingRequestList",
                    MenuName = "FundingRequestList",
                    UrlName = "FundingRequestList",
                    Description = "Funding Requests List",
                    ShowInNavigation = false,
                    TemplateName = SiteInitializer.BackendTemplateName,
                };
                pageInfo.Parameters["ModuleName"] = FundingModule.ModuleName;
                var control = new FundingRequestList();
                var node = initializer.CreatePageFromConfiguration(pageInfo, fundingRequestNode, control);
            }
        }

        /// <summary>
        /// Installs the taxonomies.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        protected override void InstallTaxonomies(SiteInitializer initializer)
        {
        }

        /// <summary>
        /// Installs module's toolbox configuration.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        protected override void InstallConfiguration(SiteInitializer initializer)
        {
            var config = initializer.Context.GetConfig<ToolboxesConfig>();
            var pageControls = config.Toolboxes["PageControls"];
            var section = pageControls
                .Sections
                .Where<ToolboxSection>(e => e.Name == ToolboxesConfig.ContentToolboxSectionName)
                .FirstOrDefault();

            // add your controls here
            //section.Tools.Add(new ToolboxItem(section.Tools)
            //{
            //    Name = "SampleModelUpload",
            //    Title = "SampleModelsUploadTitle",
            //    Description = "SampleModelsUploadDescription",
            //    ResourceClassId = typeof(FundingResources).Name,
            //    ControlType = typeof(SampleModelUpload).AssemblyQualifiedName
            //});
        }

        public static readonly Guid HomePageId = new Guid("e61f65f7-931f-4ba6-8665-c3b305acc3d9");
        public static readonly Guid ChildPageId = new Guid("59BDF5F1-BCA4-42C5-99A5-3DFC6A6881E0");
    }
}