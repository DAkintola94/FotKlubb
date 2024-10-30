using FotKlubb.Data;
using FotKlubb.Models.AccountModel;

namespace FotKlubb.Repository
{
    public class ProfileCreationRepository
    {
        private readonly AppDbContext _context;

        public ProfileCreationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateProfileModel> AddCreatedProfileToBase(CreateProfileModel createProfile)
        {
            await _context.ProfileCreation.AddAsync(createProfile); //ProfileCreation is the variable name in AppDbContext
            await _context.SaveChangesAsync();

            return createProfile;
        }


    }
}
