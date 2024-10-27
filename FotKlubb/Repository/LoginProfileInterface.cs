using FotKlubb.Models;

namespace FotKlubb.Repository
{
    public interface LoginProfileInterface
    {
        Task<LoginProfileModel> FindUserByString(LoginProfileModel loginProfile, CreateProfileModel createProfileModel, UsersActivity userActivity);

    }
}
