using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System;

namespace BusinessLogic.BuisnessLogic
{
    public class MarketLogic
    {
        private IMarketStorage marketStorage;

        public MarketLogic(IMarketStorage marketStorage)
        {
            this.marketStorage = marketStorage;
        }

        public List<MarketViewModel> Read(MarketBindingModel model)
        {
            if (model == null)
            {
                return marketStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<MarketViewModel> { marketStorage.GetElement(model) };
            }
            return marketStorage.GetFiltredList(model);
        }

        public void CreateOrUpdate(MarketBindingModel model)
        {
            
            if (model.Id.HasValue)
            {
                marketStorage.Update(model);
            }
            else
            {
                marketStorage.Insert(model);
            }
        }

        public void Delete(MarketBindingModel model)
        {
            var element = marketStorage.GetElement(model);

            if(element == null)
            {
                throw new Exception("Элемент не найден");
            }

            marketStorage.Delete(model);
        }
    }
}
