using FotKlubb.Data;
using FotKlubb.Models.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace FotKlubb.Repository
{
    public class LocationRepositorycs : ILocationRepository
    {
        private readonly AppDbContext _context;
        public LocationRepositorycs(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PositionModel> AddPosition(PositionModel positionModel)
        {
            await _context.Position_model.AddAsync(positionModel);
            await _context.SaveChangesAsync();
            return positionModel;
        }

        public async Task<IEnumerable<PositionModel>> GetAllPositions()
        {
            return await _context.Position_model.ToListAsync();
        }

        public async Task<PositionModel> GetPositionById(int? id)
        {
            return await _context.Position_model.FindAsync(id);
        }

        public async Task<PositionModel> UpdatePosition(PositionModel positionModel)
        {
            _context.Position_model.Update(positionModel);
            await _context.SaveChangesAsync();
            return positionModel;
        }

        public async Task<PositionModel> DeletePosition(int? id)
        {
            var itemId = await _context.Position_model.FindAsync(id); //remember, Product_detail is the object created in the AppDBContext
            if (itemId != null)
            {
                _context.Position_model.Remove(itemId);
                await _context.SaveChangesAsync();
            }

            return null;
        }

    }
}
