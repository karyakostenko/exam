using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IMarketStorage
    {
        List<MarketViewModel> GetFullList();
        List<MarketViewModel> GetFiltredList(MarketBindingModel model);
        MarketViewModel GetElement(MarketBindingModel model);
        void Insert (MarketBindingModel model);
        void Update(MarketBindingModel model);
        void Delete(MarketBindingModel model);
    }
}
