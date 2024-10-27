using FotKlubb.Models;

namespace FotKlubb.Repository
{
    public interface UserAcitivityInterface
    {
        Task<UsersActivity> AddActivityToBase(UsersActivity userActivity);


    }
}
