using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Flurl.Http;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Service.Queries;

using Service.Repositories;

namespace Service.Handlers
{

    public class CurrenciesConvertionsHandler: IRequestHandler<CurrenciesConvertions, string>
    {
        private const string JSON_CURRENCIES_FILENAME = "Currencies.json";
        private const string JSON_CONVERTION_FILENAME = "CurrenciesConvertion.csv";
        private readonly string SavePath;
        
        private readonly IMercadolibreRepository _repository;

        private readonly JsonSerializerSettings _jsonSettings;

        public CurrenciesConvertionsHandler(IMercadolibreRepository repository)
        {
            this._repository = repository;
            this.SavePath = Environment.GetEnvironmentVariable("SAVE_PATH") ?? Path.Combine(
                Directory.GetCurrentDirectory(), 
                "output"
            );
            
            this._jsonSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public async Task<string> Handle(CurrenciesConvertions request, CancellationToken cancellation)
        {
            List<Currency> resultCurrencies = await _repository.GetCurrencies();

            List<CurrencyConvertion> ratios = new();
            
            foreach (Currency currency in resultCurrencies)
            {
                try
                {
                    CurrencyConvertion curConv = await _repository.ConvertionToDolar(currency.id);
                    ratios.Add(curConv);
                    currency.to_dolar = curConv.inv_rate;
                }
                catch (FlurlHttpException f)
                {
                    currency.to_dolar = f.StatusCode;
                }
            }

            this.SaveCurrencies(resultCurrencies);
            this.SaveRatio(ratios);
            
            return $"Archivos de salida almacenados en: {SavePath}";
        }

        private void SaveCurrencies(List<Currency> resultCurrencies)
        {
            string jsonCurrencies = Newtonsoft.Json.JsonConvert.SerializeObject(
                resultCurrencies, 
                _jsonSettings
            );
            
            string fullPath = Path.Combine(this.SavePath, JSON_CURRENCIES_FILENAME);
            File.WriteAllText(fullPath, jsonCurrencies);
        }
        
        private void SaveRatio(List<CurrencyConvertion> ratios)
        {
            string csvRatio = string.Join(';', ratios.Select(s=>s.ratio.ToString()).ToList());
            string fullPath = Path.Combine(this.SavePath, JSON_CONVERTION_FILENAME);
            File.WriteAllText(fullPath, csvRatio);
        }
        
    }

}