namespace Meteo.Services
{
    public class MeteoHttpClient : IMeteoHttpClient
    {
        private readonly HttpClient _httpClient;

        public MeteoHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.meteo.lt/v1/");
        }
        public async Task<StationResponse> GetStation()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("stations/vilniaus-ams");
            response.EnsureSuccessStatusCode();

            var stationResponse = await response.Content
                .ReadFromJsonAsync<StationResponse>();

            return stationResponse;
        }

        public async Task<Forecast[]> GetStationByPlaceCode(string placeCode)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"places/{placeCode}/forecasts");
            response.EnsureSuccessStatusCode();

            var stationResponse = await response.Content
                .ReadFromJsonAsync<Forecast[]>();
            

            return stationResponse;
        }

      

        public async Task<TypeOfForecast> GetStationByForecastType(string placeCode, string ForecastType)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"places/{placeCode}/forecasts/{ForecastType}");
            response.EnsureSuccessStatusCode();

            var stationResponse = await response.Content
                .ReadFromJsonAsync<TypeOfForecast>();

            return stationResponse;
        }
    }
}
