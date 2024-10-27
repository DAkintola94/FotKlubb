using FotKlubb.Data;
using FotKlubb.Models;

namespace FotKlubb.Repository
{
    public class LocationRepositorycs : LocationInterface
    {
        private readonly AppDbContext _context;
        public LocationRepositorycs(AppDbContext context)
        {
            _context = context;
        }


        public async Task<PositionModel> AddPosition(PositionModel positionModel)
        {
            await _context.AddAsync(positionModel);
            await _context.SaveChangesAsync();
            return positionModel;
        }

    }
}
