using FotKlubb.Data;
using FotKlubb.Models.LocationModel;
using FotKlubb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FotKlubb.Controllers
{
    public class LocationController : Controller
    {
        private static List<PositionModel> _ListPositionModel = new List<PositionModel>();
        private static LocationRepositorycs _locationRepository;
        private readonly ILogger<LocationController> _ilogger;
        private readonly AppDbContext _context;

        public LocationController(ILogger<LocationController> iLogger, AppDbContext context, LocationRepositorycs locationRepo)
        {
            _ilogger = iLogger;
            _context = context;
            _locationRepository = locationRepo;
        }

        [HttpPost]
        public async Task<ActionResult> MapGeo(string geoJson, string description)
        {


            var locationInput = new PositionModel
            {
                InterractorId = Guid.NewGuid(), //  Generates a new Guid
                GeoJson = geoJson,
                Description = description,
                Date = DateOnly.FromDateTime(DateTime.Now) // Date is set to current date
            };

            if (ModelState.IsValid)
            {
                _ListPositionModel.Add(locationInput);
                await _locationRepository.AddPosition(locationInput);
                // Using repository to abstract away the database
                //adds the formulated model to the database through polymorphism

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
