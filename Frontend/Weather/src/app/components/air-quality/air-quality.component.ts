import { Component } from '@angular/core';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-air-quality',
  templateUrl: './air-quality.component.html',
  styleUrls: ['./air-quality.component.css']
})
export class AirQualityComponent {
  airQualityData: any;
  city: string = '';

  constructor(private weatherService: WeatherService) { }

  getAirQuality() {
    this.weatherService.getAirQualityByCity(this.city)
      .subscribe(data => this.airQualityData = data, error => console.error(error));
  }
}
