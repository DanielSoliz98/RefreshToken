import { Component, OnInit } from '@angular/core';
import Forecast from 'src/app/models/forecast';
import { ForecastService } from 'src/app/services/forecast.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  forecasts: Forecast[] = [];
  constructor(private service: ForecastService) { }

  ngOnInit() {
    this.getForecast();
  }

  getForecast() {
    this.service.getForecasts().subscribe(item => {
      this.forecasts = (item as Forecast[]);
      console.log(this.forecasts);
    });
  }


}
