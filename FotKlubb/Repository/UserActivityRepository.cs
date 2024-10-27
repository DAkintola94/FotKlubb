using FotKlubb.Data;
using FotKlubb.Models;

namespace FotKlubb.Repository
{
    public class UserActivityRepository : UserAcitivityInterface
    {
        private readonly AppDbContext _context;

        public UserActivityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UsersActivity> AddActivityToBase(UsersActivity userActivity)
        {
            await _context.UserActivity.AddAsync(userActivity);
            //adding user activity to the database
            //remember that UserAcity is the name of the class in the AppDbContext file

            await _context.SaveChangesAsync(); //saving all changes to the database

            return userActivity;







        }


    }
}
