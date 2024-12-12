using FotKlubb.Models.DomainModel;

namespace FotKlubb.Repository
{
    public interface ILocationRepository
    {
        Task<PositionModel> AddPosition(PositionModel positionModel);
        Task<IEnumerable<PositionModel>> GetAllPositions();
        Task<PositionModel> GetPositionById(int? id);
        Task<PositionModel> UpdatePosition(PositionModel positionModel);
        Task<PositionModel> DeletePosition(int? id);


    }
}
