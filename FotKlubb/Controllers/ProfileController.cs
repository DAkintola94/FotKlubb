using FotKlubb.Data;
using FotKlubb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FotKlubb.Controllers
{
    public class ProfileController : Controller
    {
        private static List<CreateProfileModel> _profileCreationList = new List<CreateProfileModel>();
        private readonly ILogger<ProfileController> _logger;
        private readonly AppDbContext _context;

        public ProfileController(ILogger<ProfileController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;

        }
        public IActionResult LogOut()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ProfileAccess()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginProfileModel loginProfile, UsersActivity user_activity)
        {
            var userNameFetch = await _context.ProfileCreation.
                FirstOrDefaultAsync(u => u.Username == loginProfile.Username);
            //This is to find/get data from the database 
            // _context.ProfileCreation, that is the name of the class in the AppDbContext file
            // == loginProfile (model variable, not dbcontext) because we are trying to provide data during live, against data stored in the database
            if(userNameFetch == null)
            {
                return Redirect("ForgotPassword");
                
            }

            if (userNameFetch.Password != loginProfile.Password)
            {
                return Redirect("ForgotPassword");
            }
            
            user_activity.LoginId = userNameFetch.Id;
            user_activity.UserName = userNameFetch.Username;

			_context.UserActivity.Add(user_activity);

            await _context.SaveChangesAsync();
         
            return View("MyProfile",user_activity);
        }

        [HttpGet]
        public IActionResult MyProfile()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ProfileAccess(CreateProfileModel profileCreation)
        {
            if (ModelState.IsValid)
            {
                 _context.ProfileCreation.Add(profileCreation);
                //reason for !ProfileCreation!, check the appdbcontext variable you set!

               await _context.SaveChangesAsync();
                //save the changes to the database

                _profileCreationList.Add(profileCreation);

                return Redirect("MyProfile");
            }
            return View("LogOut");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

    }
}
