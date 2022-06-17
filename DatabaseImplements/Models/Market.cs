using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplements.Models
{
    public class Market
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [ForeignKey("MarketId")]  //звязь
        public virtual List<Goods> MarketGoodses { get; set; }

        public string Author { get; set; }
    }
}
