using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System;

namespace BusinessLogic.BuisnessLogic
{
    public class GoodsLogic
    {
        private IGoodsStorage goodsStorage;

        public GoodsLogic(IGoodsStorage goodsStorage)
        {
            this.goodsStorage = goodsStorage;
        }

        public List<GoodsViewModel> Read(GoodsBindingModel model)
        {
            if (model == null)
            {
                return goodsStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<GoodsViewModel> { goodsStorage.GetElement(model) };
            }
            return goodsStorage.GetFiltredList(model);
        }

        public void CreateOrUpdate(GoodsBindingModel model)
        {

            if (model.Id.HasValue)
            {
                goodsStorage.Update(model);
            }
            else
            {
                goodsStorage.Insert(model);
            }
        }

        public void Delete(GoodsBindingModel model)
        {
            var element = goodsStorage.GetElement(model);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            goodsStorage.Delete(model);
        }
    }
}
