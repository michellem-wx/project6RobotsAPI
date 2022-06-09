namespace RobotLocator.Services
{

    // This is your middleware
    // Using the API and adding into the method
    // API is the service that is running
    public class LocationService
    {
        private readonly ILogger<LocationService> _logger;
        private readonly HttpClient _httpClient;

        // The constructor
        // httpclient is the dependency injection
        // why we're using this? to get information somewhere else
        // get it from the MAPS api
        public LocationService (IConfiguration config, HttpClient client, ILogger<LocationService>)
        {
            _httpClient = client;
            _logger = logger;
            _logger.LogCritical("Message created: Log critical message");

            // needed for the 3rd party (related to headers)

            client.DefaultRequestHeaders.Add(name,value);
        }

        public async Task<string> GetNearestBodyOfWater(Location location)
        {
            // This part of the method would need to change based on the location
            // Location is sent by the client
            // Our server is to return specific coordinates

            //HttpClient client = new HttpClient();

            //**KEEP**
            HttpResponseMessage x = await _httpClient.GetAsync("https://nominatim.openstreetmap.org/reverse?format=json&lat=-32&lon=151.2082848");
            return await x.Content.ReadAsStringAsync();

            // Adding in the client request for long and latitude:
            //HttpResponseMessage ResponseFromApi = await _httpClient.GetAsync("https://nominatim.openstreetmap.org/reverse?format=json&lat=-32&lon=151.2082848");

            



        }
    }
}

// need to store coordinates
// need to send them these coordinates
