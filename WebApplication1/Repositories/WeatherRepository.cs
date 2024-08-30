using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using System.Text.Json;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

    public WeatherRepository(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _apiKey = config["env:OpenWeatherApiKey"];
    }

    public async Task<string> GetCurrentWeatherByCityAsync(string city)
    {
        var response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric");
        //Console.WriteLine(response);
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        return data;
        //return JsonSerializer.Deserialize<WeatherData>(data);
    }

    public async Task<string> GetWeatherForecastByCityAsync(string city)
    {
        var response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/forecast?q={city}&appid={_apiKey}");
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        return data;
    }

    public async Task<string> GetAirQualityByCityAsync(string city)
    {
        var (lat, lon) = await GetCityCoordinatesAsync(city);
        var response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/air_pollution?lat={lat}&lon={lon}&appid={_apiKey}");
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        return data;
    }

    public async Task<string> GetCurrentWeatherByPincodeAsync(string pincode)
    {
        var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?zip={pincode},in&appid={_apiKey}");
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        return data;
    }

    public async Task<(double lat, double lon)> GetCityCoordinatesAsync(string city)
    {
    var response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}");
    response.EnsureSuccessStatusCode();
 
    var data = await response.Content.ReadAsStringAsync();
    var weatherData = JObject.Parse(data);
 
    double lat = (double)weatherData["coord"]["lat"];
    double lon = (double)weatherData["coord"]["lon"];
 
    return (lat, lon);
    }
    }
}