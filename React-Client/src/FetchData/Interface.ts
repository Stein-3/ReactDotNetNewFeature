interface WetherForecast {
  Date: Date;
  TemperatureC: Number;
  Summary: string;
  TemperatureF?: Number;
}

export type WetherForecasts = WetherForecast[];
