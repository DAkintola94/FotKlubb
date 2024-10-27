using FotKlubb.Models;

namespace FotKlubb.Repository
{
    public interface LocationInterface
    {
        Task<PositionModel> AddPosition(PositionModel positionModel);

    }
}
