using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IWeatherRepository
    {
        Task<string> GetCurrentWeatherByCityAsync(string city);
        Task<string> GetCurrentWeatherByPincodeAsync(string pincode);
        Task<string> GetWeatherForecastByCityAsync(string city);
        Task<string> GetAirQualityByCityAsync(string city);
    }
}