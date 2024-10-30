using FotKlubb.Models.Activity;

namespace FotKlubb.Repository
{
    public interface UserAcitivityInterface
    {
        Task<UsersActivity> AddActivityToBase(UsersActivity userActivity);


    }
}
