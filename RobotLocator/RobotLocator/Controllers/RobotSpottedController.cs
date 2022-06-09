using Microsoft.AspNetCore.Mvc;
using RobotLocator.Services;

namespace RobotLocator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotSpottedController : ControllerBase // Maps a request to a response
    {
        private readonly ILogger<RobotSpottedController> _logger;
        private readonly LocationService _service;


        // **EXAMPLE***
        // Hard coding a return value
        private List<Location> _location = new List<Location>()
        {
            // Creating a new location
            new Location()
            {
                LocationName = "Sydney Harbour",
                Longitude = 8,
                Latitude = 125,
            }
        };


        // Inject LocationService into the constructor
        public RobotSpottedController(LocationService service, ILogger<RobotSpottedController> logger)
        {
            _service = service;
            _logger = logger;
            //_logger.LogCritical("Message created: Log critical message");
        }

        // Get endpoint
        [HttpGet(Name = "RobotSpotted")]
        public string Get()
        {
            return "Sydney Harbour";
        }

        //** POST ** //
        // Location class --> the property is location of the Robot
        // The post is taking in a location 
        // The parameters in Swagger UI is telling us what parameter we're using
        // In JSON format for the location name
        // This is the information we're returning back to the user

        // Post is sending data
        #region keep
        [HttpPost(Name = "RobotSpotted")]
        public async Task<string> Post(Location location)
        {
            // someone makes a request using post, and triggers the method and calls the service method.
            var x = await _service.GetNearestBodyOfWater(location);
            return x;
        }
        #endregion


        // ** THE METHOD THAT IS USED TO RETURN THE VALUES ABOVE
        //[HttpPost(Name = "RobotSpotted")]
        //public Location Post(Location location, CancellationToken token)
        //{
        //    return _location.First();
        //}


    }
}