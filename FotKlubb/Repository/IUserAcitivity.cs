using FotKlubb.Models.DomainModel;

namespace FotKlubb.Repository
{
    public interface IUserAcitivity
    {
        Task<UsersActivity> AddActivityToBase(UsersActivity userActivity);
        Task<IEnumerable<UsersActivity>> GetAllActivities();
        Task<UsersActivity> GetActivityById(int? id);
        Task<UsersActivity> UpdateActivity(UsersActivity userActivity);
        Task<UsersActivity> DeleteActivity(int? id);

    }
}
