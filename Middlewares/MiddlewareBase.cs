using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Service.Middlewares;

public class MiddlewareBase
{
    private readonly JsonSerializerSettings _jsonSettings;

    public MiddlewareBase()
    {
        _jsonSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
    }
    
    public async Task AssignDataToResponse(
        HttpResponse response, 
        HttpStatusCode httpCode, 
        KeyValuePair<string,StringValues> headerValues, 
        dynamic bodyResponse)
    {
        
            response.Clear();

            response.StatusCode = (int) httpCode;
            response.Headers.Add(headerValues);
            string json = JsonConvert.SerializeObject(
                bodyResponse, _jsonSettings
            );
            
            await response.WriteAsync(json);
    }
}
 