using CurrencyConverter.Core;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyConverterController
    {
        private readonly ICurrencyConverter _currencyConverter;

        public CurrencyConverterController(ICurrencyConverter currencyConverter)
        {
            _currencyConverter = currencyConverter;
        }

        [HttpGet]
        [Route("/convertToRubles")]
        public double ConvertCurrencyToRubles(string currencyCode, double amount)
        {
            return _currencyConverter.ConvertToRubles(currencyCode, amount);
        }
        
        [HttpGet]
        [Route("/convertFromRubles")]
        public double ConvertRublesToCurrency(string convertingCurrencyCode, double amount)
        {
            return _currencyConverter.ConvertFromRubles(convertingCurrencyCode, amount);
        }
        
        [HttpGet]
        [Route("/convertCurrency")]
        public double ConvertCurrency(string currencyCode, string convertingCurrencyCode, double amount)
        {
            return _currencyConverter.ConvertCurrency(currencyCode, convertingCurrencyCode, amount);
        }
    }
}