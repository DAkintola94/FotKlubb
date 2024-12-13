using FotKlubb.Data;
using FotKlubb.Models.DomainModel;
using FotKlubb.Models.ViewModel;
using FotKlubb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FotKlubb.Controllers
{
    public class LocationController : Controller
    {
        private static ILocationRepository _locationRepository;
        private readonly ILogger<LocationController> _ilogger;
        private readonly AppDbContext _context;

        public LocationController(ILogger<LocationController> iLogger, AppDbContext context, ILocationRepository locationRepo)
        {
            _ilogger = iLogger;
            _context = context;
            _locationRepository = locationRepo;
        }

        [HttpPost]
        public async Task<ActionResult> MapGeo(PositionViewModel positionViewModel)
        {
            if(ModelState.IsValid) //if not null, we are attaching the data from the viewmodel (which we get from the html), to the domain model, which will go into the database
            {
                var positionModel = new PositionModel //the variable of domain model (left) will be assigned the data from the viewmodel (right)
                                                      //this works as long as they have the same data types
                {
                    Address = positionViewModel.GeoJson,
                    Description = positionViewModel.Description,
                    Title = positionViewModel.Title,
                    DateCreated = positionViewModel.DateCreated,
                };
                await _locationRepository.AddPosition(positionModel);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult MapGeo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowLocationInput()
        {
            return View();
        }
    }
}
