using System;
using System.Collections.Generic;

namespace BusinessLogic.BindingModels
{
    public class MarketBindingModel  //для записи в бд
    {
        public int? Id { get; set; }   //заполняем по варику

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime DateCreate { get; set; }

        public Dictionary<int, (int, string)> ProductComponents { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
