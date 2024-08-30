import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  private apiUrl = 'http://localhost:5089/api/Weather'; // Update with your API base URL

  constructor(private http: HttpClient) { }

  getCurrentWeatherByCity(city: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/current?city=${city}`);
  }

  getWeatherForecastByCity(city: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/forecast?city=${city}`);
  }

  getAirQualityByCity(city: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/airquality?city=${city}`);
  }

  getCurrentWeatherByPincode(pincode: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/currentbypincode?pincode=${pincode}`);
  }

 
}
