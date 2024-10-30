using FotKlubb.Data;
using FotKlubb.Models.AccountModel;
using FotKlubb.Models.Activity;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.CRUD;

namespace FotKlubb.Repository
{
    public class LoginProfileRepository : LoginProfileInterface
    {
         private readonly AppDbContext _context;

        public LoginProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LoginProfileModel> FindUserByString(LoginProfileModel loginProfil, CreateProfileModel createProfileModel, UsersActivity userActivity)
        {
            
              //saving all changes to the database

            return null;
        }




    }
}
