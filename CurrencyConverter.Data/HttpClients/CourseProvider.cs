using System.Net.Http;
using System.Net.Http.Json;
using CurrencyConverter.Core;
using CurrencyConverter.Data.HttpClients.Models;

namespace CurrencyConverter.Data.HttpClients
{
    public class CourseProvider : ICourseProvider
    {
        private readonly HttpClient _client;

        public CourseProvider(HttpClient client)
        {
            _client = client;
        }
        
        public int GetCourse(string currencyCode)
        {
            var response = _client.GetFromJsonAsync<CourseResponse>("daily_json.js")
                .GetAwaiter().GetResult();
            
            return (int) response.Valute[currencyCode].Value;
        }
    }
}