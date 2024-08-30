import { Component } from '@angular/core';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-pincode',
  templateUrl: './pincode.component.html',
  styleUrls: ['./pincode.component.css']
})
export class PincodeComponent {
  weatherData: any;
  pincode: string = '';

  constructor(private weatherService: WeatherService) { }

  getWeatherByPincode() {
    this.weatherService.getCurrentWeatherByPincode(this.pincode).subscribe(
      (data) => {
        this.weatherData = data;
      },
      (error) => {
        console.error('Error fetching weather data', error);
      }
    );
  }
}
