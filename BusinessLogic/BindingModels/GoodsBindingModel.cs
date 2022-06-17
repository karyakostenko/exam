using System;
using System.Collections.Generic;

namespace BusinessLogic.BindingModels
{
    public class GoodsBindingModel  //для записи в бд
    {
        public int? Id { get; set; }    //по варианту заполняем

        public string Name { get; set; }

        public int Cost { get; set; }

        public DateTime DateCreate { get; set; }

        public string FirmName { get; set; }

        public int MarketId { get; set; }
    }
}
