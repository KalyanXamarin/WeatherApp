using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.WebServices.DTO
{
    public class WeatherDTO
    {
        [JsonProperty("weather")]
        public List<WeatherInfoDTO> WeatherInfo { get; set; }
        [JsonProperty("main")]
        public MainDTO Main { get; set; }
        [JsonProperty("visibility")]
        public int Visibility { get; set; }
        [JsonProperty("wind")]
        public WindDTO Wind { get; set; }
        [JsonProperty("clouds")]
        public CloudsDTO Clouds { get; set; }
        [JsonProperty("dt")]
        public int Date { get; set; }
        [JsonProperty("sys")]
        public SystemDTO SystemDto { get; set; }
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string NAME { get; set; }
        [JsonProperty("cod")]
        public int Code { get; set; }
    }

    public class SystemDTO
    {
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty("sunset")]
        public int SunSet { get; set; }
    }

    public class WeatherInfoDTO
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("Main")]
        public string main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class MainDTO
    {
        [JsonProperty("temp")]
        public double Temprature { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("temp_min")]
        public double Temp_min { get; set; }
        [JsonProperty("temp_max")]
        public double Temp_max { get; set; }
    }

    public class WindDTO
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public double Degree { get; set; }
    }

    public class CloudsDTO
    {
        [JsonProperty("all")]
        public double All { get; set; }
    }
}
