using Microsoft.AspNetCore.Mvc;

namespace FotKlubb.Controllers
{
    public class SocialMedia : Controller
    {
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
