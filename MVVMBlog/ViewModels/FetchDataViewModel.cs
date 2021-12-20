using MVVMBlog.Models;
using System.Linq;

namespace MVVMBlog.ViewModels
{
    public class FetchDataViewModel
    {
        public List<WeatherForecast> forecasts { get; set; } = new();

        private readonly FetchDataModel _fetchDataModel;

        public EventHandler? wetherForecastChanged;

        public FetchDataViewModel(FetchDataModel fetchDataModel)
        {
            _fetchDataModel = fetchDataModel;
            _fetchDataModel.WetherForecastChanged += handler;
        }

        private void handler(object? s, WeatherForecast[]? e) => OnWetherForecastChanged(e);

        public async Task GetWetherForecastAsync()
        {
            await _fetchDataModel.GetWetherForecastAsync();
        }

        public void OnWetherForecastChanged(WeatherForecast[]? weatherForecasts)
        {
            if (weatherForecasts == null) return;

            var newDateList = weatherForecasts.Select(each => each.Date).ToHashSet();
            var oldDateList = forecasts.Select(each => each.Date).ToHashSet();

            var updateDateList = newDateList
                .Intersect(oldDateList);

            var additionDateList = newDateList.Except(updateDateList);
            var deleteDateList = oldDateList.Except(updateDateList);

            foreach (var updateDate in updateDateList)
            {
                var updateTarget = forecasts.FirstOrDefault(each => each.Date == updateDate);
                updateTarget = weatherForecasts.FirstOrDefault(each => each.Date == updateDate);
            }

            foreach (var additionDate in additionDateList)
            {
                var additionTarget = weatherForecasts.FirstOrDefault(each => each.Date == additionDate);
                if (additionTarget is null) return;

                forecasts.Add(additionTarget);
            }

            foreach (var deleteDate in deleteDateList)
            {
                var deleteTarget = forecasts.FirstOrDefault(each => each.Date == deleteDate);
                if (deleteTarget is null) return;

                forecasts.Remove(deleteTarget);
            }

            wetherForecastChanged?.Invoke(this, null);
        }

        ~FetchDataViewModel() => _fetchDataModel.WetherForecastChanged -= handler;
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}