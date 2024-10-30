using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.ShopModel
{
    public class CategoryModel
    {

        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<MarketModel> Products { get; set; } = new List<MarketModel>();
    }
}
