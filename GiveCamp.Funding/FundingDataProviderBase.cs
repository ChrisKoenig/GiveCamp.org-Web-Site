using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GiveCamp.Funding.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.GenericContent;

namespace GiveCamp.Funding
{
    public abstract class FundingDataProviderBase : ContentDataProviderBase
    {
        public override string RootKey
        {
            get { return "FundingDataProvider"; }
        }

        public abstract FundingModel CreateFundingRequest();

        public abstract FundingModel CreateFundingRequest(Guid id);

        public abstract IQueryable<FundingModel> GetFundingRequests();

        public abstract FundingModel GetFundingRequest(Guid id);

        public abstract void DeleteFundingRequest(FundingModel fundingRequest);

        public override object CreateItem(Type itemType, Guid id)
        {
            if (itemType == null)
                throw new ArgumentNullException("itemType");

            if (itemType == typeof(FundingModel))
                return this.CreateFundingRequest(id);

            throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
        }

        public override object GetItem(Type itemType, Guid id)
        {
            if (itemType == null)
                throw new ArgumentNullException("itemType");

            if (itemType == typeof(FundingModel))
                return this.GetFundingRequest(id);

            return base.GetItem(itemType, id);
        }

        public override void DeleteItem(object item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            var itemType = item.GetType();

            if (itemType == typeof(FundingModel))
            {
                this.DeleteFundingRequest((FundingModel)item);
                return;
            }

            throw GetInvalidItemTypeException(item.GetType(), this.GetKnownTypes());
        }

        public override IEnumerable GetItems(Type itemType, string filterExpression, string orderExpression, int skip, int take, ref int? totalCount)
        {
            if (itemType == null)
                throw new ArgumentNullException("itemType");

            if (itemType == typeof(Comment))
            {
                return new List<Comment>();
            }

            if (itemType == typeof(FundingModel))
                return SetExpressions(this.GetFundingRequests(), filterExpression, orderExpression, skip, take, ref totalCount);

            throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
        }

        public override Type[] GetKnownTypes()
        {
            return new[] { typeof(FundingModel) };
        }

        public override Type GetParentTypeFor(Type contentType)
        {
            return null;
        }

        public override IEnumerable GetItemsByTaxon(Guid taxonId, bool isSingleTaxon, string propertyName, Type itemType, string filterExpression, string orderExpression, int skip, int take, ref int? totalCount)
        {
            return null;
        }

        public override Type GetUrlTypeFor(Type itemType)
        {
            return null;
        }
    }
}