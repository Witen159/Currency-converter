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
        public int Get(string currencyCode, int amount)
        {
            return _currencyConverter.ConvertToRubles(currencyCode, amount);
        }
    }
}