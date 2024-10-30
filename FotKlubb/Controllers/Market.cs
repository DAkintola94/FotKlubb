using Microsoft.AspNetCore.Mvc;

namespace FotKlubb.Controllers
{
	public class Market : Controller
	{
		public IActionResult Shop()
		{
			return View();
		}

		public IActionResult Cart()
		{
			return View();
		}
	}
}
