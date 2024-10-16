using FotKlubb.Data;
using FotKlubb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FotKlubb.Controllers
{
    public class LocationController : Controller
    {
        private static List<PositionModel> _ListPositionModel = new List<PositionModel>();
        private readonly ILogger<LocationController> _ilogger;
        private readonly AppDbContext _context;

        public LocationController(ILogger<LocationController> iLogger, AppDbContext context)
        {
            _ilogger = iLogger;
            _context = context;

        }

        [HttpPost]
        public IActionResult MapGeo(PositionModel positionModel)
        {


            if (ModelState.IsValid)
            {
                _ListPositionModel.Add(positionModel);
                _context.Position_model.Add(positionModel); //add the list to the table. Also, 
                                                            //we _context.whatsoever because we can have several entity setup         
                _context.SaveChanges();
                _ilogger.LogInformation("Location added");
                return View("ShowLocationInput", _ListPositionModel);
            }
            return View();
        }

        [HttpGet]
        public IActionResult MapGeo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowLocationInput()
        {
            return View(_ListPositionModel);
        }
    }
}
