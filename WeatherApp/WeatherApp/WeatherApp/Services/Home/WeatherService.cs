using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Helpers;
using WeatherApp.WebServices;
using WeatherApp.WebServices.DTO;

namespace WeatherApp.Services.Home
{
    public class WeatherService
    {
        public async Task<ServiceResult<WeatherDTO>> GetWeatherInfo(double latitude,double longitude)
        {
            var serviceCall = new ServiceRepository<WeatherDTO>(GlobalConstants.ServiceHost, $"/weather?lat={latitude}&lon={longitude}&appid={GlobalConstants.API_KEY}");
            return await serviceCall.GetRequest();
        }
    }
}
