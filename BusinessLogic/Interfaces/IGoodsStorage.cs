using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces   // для связи 
{
    public interface IGoodsStorage
    {
        List<GoodsViewModel> GetFullList();
        List<GoodsViewModel> GetFiltredList(GoodsBindingModel model);
        GoodsViewModel GetElement(GoodsBindingModel model);
        void Insert(GoodsBindingModel model);
        void Update(GoodsBindingModel model);
        void Delete(GoodsBindingModel model);
    }
}
