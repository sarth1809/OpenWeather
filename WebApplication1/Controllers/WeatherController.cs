using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeatherByCity(string city)
        {
            try
            {
                var weather = await _weatherRepository.GetCurrentWeatherByCityAsync(city);
                if (weather == null)
                {
                    return NotFound($"Weather data for city '{city}' not found.");
                }
                return Ok(weather);
            }
            catch (HttpRequestException ex)
            {
                // Handle network-related errors
                return StatusCode(503, "Error fetching data from the weather service. Please try again later.");
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpGet("forecast")]
        public async Task<IActionResult> GetWeatherForecastByCity(string city)
        {
            try
            {
                var forecast = await _weatherRepository.GetWeatherForecastByCityAsync(city);
                if (forecast == null || !forecast.Any())
                {
                    return NotFound($"Forecast data for city '{city}' not found.");
                }
                return Ok(forecast);
            }
            catch (HttpRequestException ex)
            {
                // Handle network-related errors
                return StatusCode(503, "Error fetching data from the weather service. Please try again later.");
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpGet("airquality")]
        public async Task<IActionResult> GetAirQualityByCity(string city)
        {
            try
            {
                var airQuality = await _weatherRepository.GetAirQualityByCityAsync(city);
                if (airQuality == null)
                {
                    return NotFound($"Air quality data for city '{city}' not found.");
                }
                return Ok(airQuality);
            }
            catch (HttpRequestException ex)
            {
                // Handle network-related errors
                return StatusCode(503, "Error fetching data from the weather service. Please try again later.");
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpGet("currentbypincode")]
        public async Task<IActionResult> GetCurrentWeatherByPincode(string pincode)
        {
            try
            {
                var weather = await _weatherRepository.GetCurrentWeatherByPincodeAsync(pincode);
                if (weather == null)
                {
                    return NotFound($"Weather data for pincode '{pincode}' not found.");
                }
                return Ok(weather);
            }
            catch (HttpRequestException ex)
            {
                // Handle network-related errors
                return StatusCode(503, "Error fetching data from the weather service. Please try again later.");
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
