using FotKlubb.Data;
using FotKlubb.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult ProfileAccess()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginProfileModel loginProfile)
        {
            return Ok();
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
                _context.ProfileCreation.Add(profileCreation); //reason for !ProfileCreation!, check the appdbcontext variable you set!!!
                _profileCreationList.Add(profileCreation);
            }
            return Ok();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

    }
}
