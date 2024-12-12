using FotKlubb.Data;
using FotKlubb.Models.DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FotKlubb.Repository
{
    public class UserActivityRepository : IUserAcitivity
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

        public async Task<IEnumerable<UsersActivity>> GetAllActivities()
        {
            return await _context.UserActivity.ToListAsync();
        }

        public async Task<UsersActivity> GetActivityById(int? id)
        {
            var findById = await _context.UserActivity.FindAsync(id);
            if (findById != null)
            {
                return findById;
            }

            return null;
        }

        public async Task<UsersActivity> DeleteActivity(int? id)
        {
            var userActivityValue = await _context.UserActivity.FindAsync(id);

            if(userActivityValue!= null)
            {
                _context.UserActivity.Remove(userActivityValue);
                await _context.SaveChangesAsync();
                return userActivityValue;
            }

            return null;
        }

        public async Task<UsersActivity> UpdateActivity(UsersActivity userActivity)
        {
           
            _context.UserActivity.Update(userActivity);
            await _context.SaveChangesAsync();
            return userActivity;
        }

    }
}
