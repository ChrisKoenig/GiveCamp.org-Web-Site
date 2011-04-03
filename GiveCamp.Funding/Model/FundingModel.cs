using System;
using Telerik.OpenAccess;
using Telerik.Sitefinity;
using Telerik.Sitefinity.GenericContent.Model;

namespace GiveCamp.Funding.Model
{
    [ManagerType("GiveCamp.Funding.FundingManager, Funding")]
    [Persistent(IdentityField = "contentId")]
    public class FundingModel : Content
    {
        public override bool SupportsContentLifecycle
        {
            get { return false; }
        }

        [FieldAlias("eventName")]
        public string EventName { get; set; }

        [FieldAlias("eventDate")]
        public DateTime? EventDate { get; set; }

        [FieldAlias("contactFirstName")]
        public string ContactFirstName { get; set; }

        [FieldAlias("contactLastName")]
        public string ContactLastName { get; set; }

        [FieldAlias("contactAddress")]
        public string ContactAddress { get; set; }

        [FieldAlias("contactCity")]
        public string ContactCity { get; set; }

        [FieldAlias("contactState")]
        public string ContactState { get; set; }

        [FieldAlias("contactZipCode")]
        public string ContactZipCode { get; set; }

        [FieldAlias("contactPhoneNumber")]
        public string ContactPhoneNumber { get; set; }

        [FieldAlias("contactEmailAddress")]
        public string ContactEmailAddress { get; set; }

        [FieldAlias("amountRequested")]
        public decimal AmountRequested { get; set; }
    }
}