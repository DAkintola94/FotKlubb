﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotKlubb.Models.ShopModel
{
    public class MarketModel
    {
        [Key]
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductType { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public CategoryModel Category { get; set; }

    }
}
