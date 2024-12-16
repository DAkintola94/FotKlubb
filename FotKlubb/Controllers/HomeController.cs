using FotKlubb.Models;
using FotKlubb.Models.DomainModel;
using FotKlubb.Models.ViewModel;
using FotKlubb.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FotKlubb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMarketRepository _marketRepository;
        private readonly IUserAcitivity _userAcitivityRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUsersPostRepository _usersPostRepository;

        public HomeController(ILogger<HomeController> logger, IMarketRepository marketRepository
            , IUserAcitivity userActivity, ILocationRepository iLocationRepository,
            SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
            IUsersPostRepository usersPostRepository)
        {
            _logger = logger;
            _marketRepository = marketRepository;
            _userAcitivityRepository = userActivity;
            _locationRepository = iLocationRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _usersPostRepository = usersPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var getAllPost = await _usersPostRepository.GetAllUserPost();
            if(getAllPost!=null)
            {
                var homeViewModel = getAllPost.Select(data => new HomeViewModel
                {
                    UsersPostId = data.PostId,
                    UsersTitle = data.Title,
                    Description = data.Description,
                    ProfileImageUrl = data.ImageUrl,
                    Date = data.Date,
                    Location = data.Location,
                    //ProfileImageUrl = data.User.ImageUrl,
                    Age = data.UsersAge,
                    FirstName = data.FirstName,
                    LastName = data.LastName
                }).ToList();
                return View(homeViewModel);
            }

            return NotFound();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
