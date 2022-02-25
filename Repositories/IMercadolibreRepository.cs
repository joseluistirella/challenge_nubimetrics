using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Flurl;
using Flurl.Http;

namespace Service.Repositories
{
    public interface IMercadolibreRepository
    {

        Task<Country> GetOneCountry(string countryCode);

        Task<Search> Search(string query);

        Task<List<Currency>> GetCurrencies();

        Task<CurrencyConvertion> ConvertionToDolar(string currency);

    }
}
