using FotKlubb.Models.DomainModel;

namespace FotKlubb.Repository
{
    public interface IMarketRepository
    {
        Task<IEnumerable<MarketModel>> GetAllMarket();
        Task<MarketModel> GetMarketById(int? id);
        Task<MarketModel> AddMarket(MarketModel marketModel);
        Task<MarketModel> UpdateMarket(MarketModel marketModel);
        Task<MarketModel> DeleteMarket(int? id);


    }
}
