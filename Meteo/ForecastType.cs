namespace Meteo
{

    public class TypeOfForecast
    {
        public Place place { get; set; }
        public string forecastType { get; set; }
        public string forecastCreationTimeUtc { get; set; }
        public Forecasttimestamp[] forecastTimestamps { get; set; }
    }

    public class Place
    {
        public string code { get; set; }
        public string name { get; set; }
        public string administrativeDivision { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public Coordinates coordinates { get; set; }
    }



    public class Forecasttimestamp
    {
        public string forecastTimeUtc { get; set; }
        public float airTemperature { get; set; }
        public float feelsLikeTemperature { get; set; }
        public int windSpeed { get; set; }
        public int windGust { get; set; }
        public int windDirection { get; set; }
        public int cloudCover { get; set; }
        public int seaLevelPressure { get; set; }
        public int relativeHumidity { get; set; }
        public float totalPrecipitation { get; set; }
        public string conditionCode { get; set; }
    }

}
