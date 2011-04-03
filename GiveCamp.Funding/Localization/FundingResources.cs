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
        public string SampleResourcesTitle
        {
            get
            {
                return this["SampleResourcesTitle"];
            }
        }

        [ResourceEntry("SampleResourcesDescription",
                       Value = "Contains localizable resources for Sample module labels.",
                       Description = "The description of this class.",
                       LastModified = "2009/04/30")]
        public string SampleResourcesDescription
        {
            get
            {
                return this["SampleResourcesDescription"];
            }
        }

        [ResourceEntry("SampleResourcesTitlePlural",
            Value = "FundingResources",
            Description = "The title plural of this class.",
            LastModified = "2009/04/30")]
        public string SampleResourcesTitlePlural
        {
            get
            {
                return this["SampleResourcesTitlePlural"];
            }
        }

        #endregion Class Description
    }
}