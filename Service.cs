using System;
using System.Threading.Tasks;

using Flurl;
using Flurl.Http;

namespace ml
{
    public class CountryServices
    {

        public async Task<Country> GetCurrencies(string countryCode)
        {
            var country = await "https://api.mercadolibre.com/classified_locations/countries"
                .AppendPathSegment(countryCode)
                .GetAsync()
                .ReceiveJson<Country>();

            return country;

        }

    }
}
