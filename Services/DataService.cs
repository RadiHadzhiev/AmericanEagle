using Asteroids.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace Asteroids.Services
{
    public class DataService : IDataService
    {
        private const string neoFeed = @"https://api.nasa.gov/neo/rest/v1/feed";
        private const string apodAddress = @"https://api.nasa.gov/planetary/apod";
        private const string dateFormat = "yyy-MM-dd";
        private Dictionary<string, string> queryParameters;
        public DataService()
        {
            queryParameters = new Dictionary<string, string>();
            queryParameters.Add("api_key", "DEMO_KEY");

        }

        public Neo GetData()
        {
            throw new NotImplementedException();
        }

        public async Task<Neo>? GetDataInRange(DateTime startDate, DateTime endDate)
        {

            if (startDate == DateTime.MinValue)
            {
                startDate = DateTime.Today;
            }
            if (endDate == DateTime.MinValue)
            {
                endDate = DateTime.Today.AddDays(7);
            }

            string dataStart = startDate.ToString(dateFormat);
            string dataEnd = endDate.ToString(dateFormat);

            queryParameters.Add("detailed", "false");
            queryParameters.Add("start_date", dataStart);
            queryParameters.Add("end_date", dataEnd);

            using (var client = new HttpClient())
            {
                var uri = QueryHelpers.AddQueryString(neoFeed, queryParameters);

                var result = await client.GetAsync(uri);

                if (result.IsSuccessStatusCode)
                {
                    var responce = await result.Content.ReadAsStringAsync();
                    Neo? neoData = JsonConvert.DeserializeObject<Neo>(responce);

                    neoData.DataStart = dataStart;
                    neoData.DataEnd = dataEnd;

                    return neoData;
                }
                else
                {
                    var responce = await result.Content.ReadAsStringAsync();
                    throw new ApplicationException(responce);
                }
            }

            return null;

        }

        public async Task<Apod> GetImageOfTheDay(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                date = DateTime.Today.ToString(dateFormat);
            }

            queryParameters.Add("start_date", date);
            queryParameters.Add("end_date", date);

            using (var client = new HttpClient())
            {
                var uri = QueryHelpers.AddQueryString(apodAddress, queryParameters);

                var result = await client.GetAsync(uri);

                if (result.IsSuccessStatusCode)
                {

                    var responce = await result.Content.ReadAsStringAsync();
                    Apod[] pictureData = JsonConvert.DeserializeObject<Apod[]>(responce);

                    return pictureData[0];
                }
                else
                {
                    var responce = await result.Content.ReadAsStringAsync();
                    throw new ApplicationException(responce);
                }
            }

            return null;
        }
    }
}