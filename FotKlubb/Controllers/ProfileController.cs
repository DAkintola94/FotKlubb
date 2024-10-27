using FotKlubb.Data;
using FotKlubb.Models;
using FotKlubb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FotKlubb.Controllers
{
    public class ProfileController : Controller
    {
        private static List<CreateProfileModel> _profileCreationList = new List<CreateProfileModel>();
        private readonly ILogger<ProfileController> _logger;
        private readonly AppDbContext _context;  //setting up DbContext, which have our model => entity
        private readonly UserActivityRepository _userActivityRepository;
        private readonly ProfileCreationRepository _profileCreationRepository;

        public ProfileController(ILogger<ProfileController> logger, AppDbContext context, UserActivityRepository userActivityRep, ProfileCreationRepository profileCreationRepo)
        {
            _logger = logger;
            _context = context;
            _userActivityRepository = userActivityRep;
            _profileCreationRepository = profileCreationRepo;
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
            var userNameFetch = await _context.ProfileCreation.FirstOrDefaultAsync
                (u => u.Username == loginProfile.Username && u.Password == loginProfile.Password);
            //This is to find/get data from the database, then LINQ lamba to loop through the data and get username.
            // _context.ProfileCreation, that is the name of the class in the AppDbContext file
            // == loginProfile (model variable, not dbcontext) 
            // we are trying to provide data to user "live", then match it against data stored in the database.
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

            await _userActivityRepository.AddActivityToBase(user_activity);
            // abstracting away, so controller is not responsible for the database, the repository is.


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
        public async Task<ActionResult> ProfileAccess(CreateProfileModel profileCreation, UsersActivity usersActivity)
        {
            if (ModelState.IsValid)
            {
                

                _profileCreationList.Add(profileCreation);

                await _profileCreationRepository.AddCreatedProfileToBase(profileCreation);
                // abstracting away from the controller, this is the responsibility of repository

                return Redirect("Login");
            }
            return View("LogOut");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

    }
}
