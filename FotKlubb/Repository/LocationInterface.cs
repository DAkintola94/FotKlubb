using FotKlubb.Models.LocationModel;

namespace FotKlubb.Repository
{
    public interface LocationInterface
    {
        Task<PositionModel> AddPosition(PositionModel positionModel);

    }
}
