import { Component } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-current-weather',
  templateUrl: './current-weather.component.html',
  styleUrls: ['./current-weather.component.css']
})
export class CurrentWeatherComponent {
  weatherData: any;
  city: string = '';

  constructor(private weatherService: WeatherService) { }

  getWeather() {
    this.weatherService.getCurrentWeatherByCity(this.city).subscribe(
      (data) => {
        this.weatherData = data;
      },
      (error) => {
        console.error('Error fetching weather data', error);
      }
    );
  }
}
