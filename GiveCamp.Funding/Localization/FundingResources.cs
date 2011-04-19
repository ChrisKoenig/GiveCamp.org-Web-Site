using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Localization;

namespace GiveCamp.Funding.Localization
{
    [ObjectInfo("FundingResources", ResourceClassId = "FundingResources")]
    public class FundingResources : Resource
    {
        #region Class Description

        [ResourceEntry("SampleResourcesTitle",
                       Value = "FundingResources",
                       Description = "The title of this class.",
                       LastModified = "2009/04/30")]
        public string FundingResourcesTitle
        {
            get
            {
                return this["FundingResourcesTitle"];
            }
        }

        [ResourceEntry("FundingResourcesDescription",
                       Value = "Contains localizable resources for Funding module labels.",
                       Description = "The description of this class.",
                       LastModified = "2009/04/30")]
        public string FundingResourcesDescription
        {
            get
            {
                return this["FundingResourcesDescription"];
            }
        }

        [ResourceEntry("FundingResourcesTitlePlural",
            Value = "FundingResources",
            Description = "The title plural of this class.",
            LastModified = "2009/04/30")]
        public string FundingResourcesTitlePlural
        {
            get
            {
                return this["FundingResourcesTitlePlural"];
            }
        }

        #endregion Class Description
    }
}