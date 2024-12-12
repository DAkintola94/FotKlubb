using FotKlubb.Data;
using FotKlubb.Models.DomainModel;
using FotKlubb.Models.ViewModel;
using FotKlubb.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FotKlubb.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string wwwRootPath;

        public ProfileController(ILogger<ProfileController> logger, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            wwwRootPath = _webHostEnvironment.WebRootPath;
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ProfileAccess()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel, UsersActivity user_activity)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);
            if (!signInResult.Succeeded)
            {

                loginViewModel.PasswordFailed = true;
                return View(loginViewModel);
            }


            if (signInResult != null && signInResult.Succeeded)
            {
                if (!string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                {
                    return Redirect(loginViewModel.ReturnUrl);
                }

                return RedirectToAction("ProfilePage");
            }
            return View();
        }

       [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            var getUsers = await _userManager.GetUserAsync(User);
            if (getUsers != null)
            {
                return NotFound();
            }

            ProfilePageViewModel profileViewModel = new ProfilePageViewModel //assigning the values from the ApplicationUser to the ProfilePageViewModel
                                                                             //and sending it to the view
            {
                Email = getUsers.Email, //profileviewmodel values to the left, is assisgning and becoming the values to the right(Identity from the database)
                FirstName = getUsers.FirstName,
                LastName = getUsers.LastName,
                Username = getUsers.UserName,
                PhoneNr = getUsers.PhoneNumber,
                Age = getUsers.Age,
                Address = getUsers.Address,
                ImageUrl = getUsers.ImageUrl
            };

            return View(profileViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationViewModel registrationViewModel, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser applicationUser = new ApplicationUser //assigning the values from the registrationViewModel to the ApplicationUser
                                                                      //The values to the left becomes the values to the right, we assign values like this in programming
                {
                    FirstName = registrationViewModel.FirstName,
                    LastName = registrationViewModel.LastName,
                    UserName = registrationViewModel.Username,
                    Email = registrationViewModel.Email,
                    PhoneNumber = registrationViewModel.PhoneNr,
                    Age = registrationViewModel.Age,
                    Address = registrationViewModel.Address
                };
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string uploadPath = Path.Combine(wwwRootPath, "Images", "profilepicture");

                    using (var fileStream = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    applicationUser.ImageUrl = Path.Combine("Images", "profilepicture", fileName);

                }

                var applicationResult = await _userManager.CreateAsync(applicationUser, registrationViewModel.Password); //creating the user with the password
                                                                                                                             //no need for repository, identity framework has a built in method here, and table in the database
                    if (applicationResult.Succeeded)
                    {
                        var applicationIdentity = await _userManager.AddToRoleAsync(applicationUser, "RegularUser");

                        if (applicationIdentity.Succeeded)
                        {
                            return RedirectToAction("Login");
                        }
                    }
            }

            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public async Task<IActionResult> ChangePassword(ApplicationUser applicationUser)
        {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return NotFound();
            }

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, applicationUser.PasswordHash);
            var result = await _userManager.UpdateAsync(user);
            
            return RedirectToAction("MyProfile");
            
        }

    }
}
