namespace Meteo.Services
{
    public interface IMeteoHttpClient
    {
        Task<StationResponse> GetStation();
        Task<Forecast[]> GetStationByPlaceCode(string placeCode);
        Task<TypeOfForecast> GetStationByForecastType(string placeCode, string ForecastType);
    }
}
