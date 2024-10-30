using FotKlubb.Models.AccountModel;

namespace FotKlubb.Repository
{
    public interface ProfileCreationInterface
    {
        Task<CreateProfileModel> AddCreatedProfileToBase(CreateProfileModel createProfile);


    }
}
