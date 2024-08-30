import { Component } from '@angular/core';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-forecast',
  templateUrl: './forecast.component.html',
  styleUrls: ['./forecast.component.css']
})
export class ForecastComponent {
  forecastData: any;
  city: string = '';

  constructor(private weatherService: WeatherService) { }

  getForecast() {
    this.weatherService.getWeatherForecastByCity(this.city).subscribe(
      (data) => {
        this.forecastData = data;
      },
      (error) => {
        console.error('Error fetching weather data', error);
      }
    );
  }
}
