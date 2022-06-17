using System;
using System.Collections.Generic;

namespace BusinessLogic.ViewModels
{
    public class GoodsViewModel  // вывод из бд 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MarketId { get; set; }

        public int Cost { get; set; }

        public DateTime DateCreate { get; set; }

        public string FirmName { get; set; }
    }
}
