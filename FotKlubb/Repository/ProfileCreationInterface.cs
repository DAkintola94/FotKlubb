using FotKlubb.Models;

namespace FotKlubb.Repository
{
    public interface ProfileCreationInterface
    {
        Task<CreateProfileModel> AddCreatedProfileToBase(CreateProfileModel createProfile);


    }
}
