namespace RobotLocator.Services
{

    // This is your middleware
    // Using the API and adding into the method
    // API is the service that is running
    public class LocationService
    {
        private readonly HttpClient _httpClient;
        // The constructor
        // httpclient is the dependency injection
        // why we're using this? to get information somewhere else
        // get it from the MAPS api

        //public LocationService (IConfiguration config, HttpClient client, ILogger<LocationService>)
        public LocationService(HttpClient client)
        {
            _httpClient = client;
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");
        }

        public async Task<string> GetNearestBodyOfWater(Location location)
        {
        // This part of the method would need to change based on the location
        // Location is sent by the client
        // Our server is to return specific coordinates

        //**KEEP**
        // 1. USE SEARCH QUERY URL - descriptive search

            // Random: how come it won't work with water%20'location name'..
            string APIUrl = $"https://nominatim.openstreetmap.org/search.php?q=water%20near%20{location.LocationName}%20Australia&polygon_geojson=1&format=jsonv2";

            HttpResponseMessage x = await _httpClient.GetAsync(APIUrl);

            // ReadAsStringAsync: Serialize the HTTP content to a string as an asynchronous operation.
            // return a string
            return await x.Content.ReadAsStringAsync();
          
        }
    }
}

// need to store coordinates
// need to send them these coordinates
