using FotKlubb.Models.AccountModel;
using FotKlubb.Models.Activity;

namespace FotKlubb.Repository
{
    public interface LoginProfileInterface
    {
        Task<LoginProfileModel> FindUserByString(LoginProfileModel loginProfile, CreateProfileModel createProfileModel, UsersActivity userActivity);

    }
}
