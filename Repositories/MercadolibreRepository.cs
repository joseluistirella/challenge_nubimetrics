using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Flurl;
using Flurl.Http;

namespace Service.Repositories
{
    public class MercadolibreRepository : IMercadolibreRepository
    {
        private const string GET_ONE_COUNTRY = "https://api.mercadolibre.com/classified_locations/countries";
        private const string SEARCH_COUNTRIES = "https://api.mercadolibre.com/sites/MLA/search?q={0}";
        private const string GET_ALL_CURRENCIES = $"https://api.mercadolibre.com/currencies/";
        private const string GET_CONVERTION_CURRENCY = "https://api.mercadolibre.com/currency_conversions/search?from={0}&to=USD";
            
        public async Task<Country> GetOneCountry(string countryCode)
        {
            var country = await GET_ONE_COUNTRY
                .AppendPathSegment(countryCode)
                .GetAsync()
                .ReceiveJson<Country>();

            return country;

        }
        
        public async Task<Search> Search(string query)
        {
            var search = await string.Format(SEARCH_COUNTRIES, query)  
                .GetAsync()
                .ReceiveJson<Search>();

            return search;

        }
        
        public async Task<List<Currency>> GetCurrencies()
        {
            var result = await GET_ALL_CURRENCIES
                .GetAsync()
                .ReceiveJson<List<Currency>>();

            return result;

        }
        
        public async Task<CurrencyConvertion> ConvertionToDolar(string currency)
        {
            var result = await string.Format(GET_CONVERTION_CURRENCY, currency)
                .GetAsync()
                .ReceiveJson<CurrencyConvertion>();

            return result;

        }

    }
}
