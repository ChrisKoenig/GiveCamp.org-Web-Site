using System;
using System.Linq;
using GiveCamp.Funding.Configuration;
using GiveCamp.Funding.Model;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.GenericContent;

namespace GiveCamp.Funding
{
    public class FundingManager : ContentManagerBase<FundingDataProviderBase>
    {
        public FundingManager()
            : this(null)
        {
        }

        public FundingManager(string providerName)
            : base(providerName)
        {
        }

        public FundingManager(string providerName, string transactionName)
            : base(providerName, transactionName)
        {
        }

        public override string ModuleName
        {
            get
            {
                return FundingModule.ModuleName;
            }
        }

        protected override ConfigElementDictionary<string, DataProviderSettings> ProvidersSettings
        {
            get
            {
                return Config.Get<FundingConfig>().Providers;
            }
        }

        protected override GetDefaultProvider DefaultProviderDelegate
        {
            get
            {
                return () => Config.Get<FundingConfig>().DefaultProvider;
            }
        }

        public static FundingManager GetManager()
        {
            return ManagerBase<FundingDataProviderBase>.GetManager<FundingManager>();
        }

        public static FundingManager GetManager(string providerName)
        {
            return ManagerBase<FundingDataProviderBase>.GetManager<FundingManager>(providerName);
        }

        public static FundingManager GetManager(string providerName, string transactionName)
        {
            return ManagerBase<FundingDataProviderBase>.GetManager<FundingManager>(providerName, transactionName);
        }

        public virtual FundingModel CreateFundingRequest()
        {
            return this.Provider.CreateFundingRequest();
        }

        public virtual FundingModel CreateFundingRequest(Guid id)
        {
            return this.Provider.CreateFundingRequest(id);
        }

        public virtual IQueryable<FundingModel> GetFundingRequests()
        {
            return this.Provider.GetFundingRequests();
        }

        public virtual FundingModel GetFundingRequest(Guid id)
        {
            return this.Provider.GetFundingRequest(id);
        }

        public virtual void DeleteFundingRequest(FundingModel application)
        {
            this.Provider.DeleteFundingRequest(application);
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <returns></returns>
        public override IQueryable<TItem> GetItems<TItem>()
        {
            if (typeof(FundingModel).IsAssignableFrom(typeof(TItem)))
                return this.GetFundingRequests() as IQueryable<TItem>;
            if (typeof(TItem) == typeof(Comment))
                return null;
            throw new NotSupportedException();
        }
    }
}