using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplements.Models
{
    public class Goods  // 3 задача зодание моделей (потом создаешь миграцию)
    {
        public int Id { get; set; }  // по варианту
        [Required]
        public string Name { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int MarketId { get; set; } // связь
        public virtual Market Market { get; set; }

        public DateTime DateCreate { get; set; }

        public string FirmName { get; set; }
    }
}
