using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.DomainModel
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<MarketModel> Products { get; set; } = new List<MarketModel>();
    }
}
