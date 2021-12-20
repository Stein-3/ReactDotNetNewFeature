using MVVMBlog.Models;
using System.Web;

namespace MVVMBlog.ViewModels
{
    public class FetchData2ViewModel
    {
        private readonly FetchDataModel _fetchDataModel;

        public WeatherForecast? activeForecast { get; set; }

        public FetchData2ViewModel(FetchDataModel fetchDataModel)
        {
            _fetchDataModel = fetchDataModel;
        }

        public void GetActiveForecast(string data)
        {
            DateTime.TryParse(HttpUtility.UrlDecode(data), out var target);

            activeForecast = _fetchDataModel.forecasts.FirstOrDefault(each => each.Date.ToString() == target.ToString());
        }
    }
}