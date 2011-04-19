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

        [FieldAlias("EventName")]
        public string EventName { get; set; }

        [FieldAlias("EventDate")]
        public DateTime EventDate { get; set; }

        [FieldAlias("FirstName")]
        public string FirstName { get; set; }

        [FieldAlias("LastName")]
        public string LastName { get; set; }

        [FieldAlias("Address")]
        public string Address { get; set; }

        [FieldAlias("City")]
        public string City { get; set; }

        [FieldAlias("State")]
        public string State { get; set; }

        [FieldAlias("ZipCode")]
        public string ZipCode { get; set; }

        [FieldAlias("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [FieldAlias("EmailAddress")]
        public string EmailAddress { get; set; }

        [FieldAlias("AmountRequested")]
        public decimal AmountRequested { get; set; }
    }
}