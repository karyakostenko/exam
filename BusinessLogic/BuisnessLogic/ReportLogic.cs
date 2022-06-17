using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace BusinessLogic.BuisnessLogic
{
    class ReportLogic
    {
        private readonly IMarketStorage marketStorage;

        public ReportLogic(IMarketStorage marketStorage)
        {
            this.marketStorage = marketStorage;
        }

        public List<ReportViewModel> GetOrders(MarketBindingModel model)  // запрос
        {
            var products = marketStorage.GetFiltredList(model);
            var list = new List<ReportViewModel>();
            foreach (var product in products)
            {
                var record = new ReportViewModel
                {
                    MarketName = product.Name,
                    DateCreate = product.DateCreate
                };
                foreach (var component in product.ProductComponents)
                {
                    record.GoodsName = component.Value.Item2;
                    record.GoodsCost = component.Value.Item1;
                    list.Add(record);
                }
            }
            return list;
        }
        public async void SaveJSONDataContract(MarketBindingModel model) //5 задание
        {
            await Task.Run(() =>
            {
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(List<ReportViewModel>));
                using (FileStream fs = new FileStream("otchet.json", FileMode.OpenOrCreate))
                {
                    formatter.WriteObject(fs, GetOrders(model));
                }
            });
        }

       
    }
}
