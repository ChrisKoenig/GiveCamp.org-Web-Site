using System;
using System.Linq;
using System.Reflection;
using GiveCamp.Funding.Model;
using Telerik.OpenAccess;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Data.Linq;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.GenericContent.Data;
using Telerik.Sitefinity.Security;

namespace GiveCamp.Funding.Data
{
    /// <summary>
    /// A FundingRequests provider implemented using OpenAccess
    /// </summary>
    [ContentProviderDecorator(typeof(OpenAccessContentDecorator))]
    public class OpenAccessFundingDataProvider : FundingDataProviderBase, IOpenAccessDataProvider
    {
        #region IOpenAccessDataProvider Members

        public Database Database { get; set; }

        public bool UseImplicitTransactions
        {
            get { return true; }
        }

        public Assembly[] GetPersistentAssemblies()
        {
            return new[] { typeof(FundingModel).Assembly };
        }

        #endregion IOpenAccessDataProvider Members

        public override FundingModel CreateFundingRequest()
        {
            return this.CreateFundingRequest(Guid.NewGuid());
        }

        public override FundingModel CreateFundingRequest(Guid id)
        {
            var dateValue = DateTime.UtcNow;

            var item = new FundingModel()
            {
                Id = id,
                ApplicationName = this.ApplicationName,
                Owner = SecurityManager.GetCurrentUserId(),
                DateCreated = dateValue,
                PublicationDate = dateValue
            };

            ((IDataItem)item).Provider = this;

            if (id != Guid.Empty)
            {
                this.GetScope().Add(item);
            }

            return item;
        }

        public override IQueryable<FundingModel> GetFundingRequests()
        {
            var appName = this.ApplicationName;

            var query =
                SitefinityQuery
                .Get<FundingModel>(this, MethodBase.GetCurrentMethod())
                .Where(b => b.ApplicationName == appName);

            return query;
        }

        public override FundingModel GetFundingRequest(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("id");

            var item = this.GetScope().GetItemById<FundingModel>(id.ToString());
            ((IDataItem)item).Provider = this;
            return item;
        }

        public override void DeleteFundingRequest(FundingModel application)
        {
            var scope = this.GetScope();
            if (scope != null)
            {
                scope.Remove(application);
            }
        }

        public TransactionMode TransactionConcurrency
        {
            get { return TransactionMode.OPTIMISTIC_NO_LOST_UPDATES; }
        }
    }
}