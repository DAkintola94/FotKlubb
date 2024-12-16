using Microsoft.AspNetCore.Mvc;
using FotKlubb.Repository;
using FotKlubb.Models.DomainModel;
using FotKlubb.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace FotKlubb.Controllers
{
    public class SocialMedia : Controller
    {
        private readonly IUsersPostRepository _usersPostRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public SocialMedia(IUsersPostRepository usersPostRepository, UserManager<ApplicationUser> userManager)
        {
            _usersPostRepository = usersPostRepository;
            _userManager = userManager;
        }


        [HttpPost]
        public async Task<IActionResult> MySite(UsersPostViewModel userPostViewModel)
        {
            var currentUser = await _userManager.GetUserAsync(User);


            if (userPostViewModel != null && currentUser != null)
            {
                var userPostModel = new UsersPostModel
                {
                    Title = userPostViewModel.Title,
                    Description = userPostViewModel.Description,
                    Date = userPostViewModel.Date,
                    Location = userPostViewModel.Location,
                    Category = userPostViewModel.Category,
                    UsersAge = currentUser.Age,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    ImageUrl = currentUser.ImageUrl
                };

                await _usersPostRepository.AddUsersPost(userPostModel);
                
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult MySite()
        {
            return View();
        }



        public IActionResult NewsFeed()
        {
            return View();
        }
    }
}
