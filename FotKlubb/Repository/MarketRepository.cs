using FotKlubb.Data;
using FotKlubb.Models.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace FotKlubb.Repository
{
    public class MarketRepository : IMarketRepository
    {
        private readonly AppDbContext _context;
        public MarketRepository(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<MarketModel> AddMarket (MarketModel marketModel)
        {
            if(marketModel != null)
            {
                await _context.Market.AddAsync(marketModel);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<MarketModel> DeleteMarket(int? id)
        {
            var marketValue = await _context.Market.FindAsync(id);
            if (marketValue != null)
            {
                _context.Market.Remove(marketValue);
                await _context.SaveChangesAsync();
                return marketValue;
            }
            return null;
        }

        public async Task<IEnumerable<MarketModel>> GetAllMarket()
        {
            return await _context.Market.ToListAsync();
        }

        public async Task<MarketModel> GetMarketById(int? id)
        {
            var marketValue = await _context.Market.FindAsync(id);
            if (marketValue != null)
            {
                return marketValue;
            }
            return null;
        }

        public async Task<MarketModel> UpdateMarket(MarketModel marketModel)
        {
            if (marketModel != null)
            {
                _context.Market.Update(marketModel);
                await _context.SaveChangesAsync();
            }
            return null;
        }

    }
}
