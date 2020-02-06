import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import Forecast from '../models/forecast';
import { config } from '../config';

@Injectable({
  providedIn: 'root'
})
export class ForecastService {

  constructor(private http: HttpClient) { }

  getForecasts(): Observable<Forecast[]> {
    return this.http.get<Forecast[]>(`${config.apiUrl}weather-forecast`);
  }
}
