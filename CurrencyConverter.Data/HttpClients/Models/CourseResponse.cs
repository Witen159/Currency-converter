using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CurrencyConverter.Data.HttpClients.Models
{
    public class CourseResponse
    {
        public DateTime Date { get; set; }
        public Dictionary<string, ValueItem> Valute { get; set; }
    }

    public class ValueItem
    {
        [JsonPropertyName("ID")]
        public string Id { get; set; }
        public string NumCode { get; set; }
        public int Nominal { get; set; }
        public double Value { get; set; }
    }
}