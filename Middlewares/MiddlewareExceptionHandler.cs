using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Service.Exceptions;

namespace Service.Middlewares;
public class MiddlewareExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly JsonSerializerSettings _jsonSettings;
 
    public MiddlewareExceptionHandler(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
 
        _jsonSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
    }
 
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Flurl.Http.FlurlHttpException fhe)
        {
            context.Response.Clear();

            context.Response.StatusCode = (int) HttpStatusCode.BadGateway;
            context.Response.Headers.Add("exception", "validationException");
            ModelStateDictionary modelState = new();
            string json = JsonConvert.SerializeObject(
                new
                {
                    Error = "Error de comunicación con mercadolibre",
                    TechnicalDetail = fhe.Message
                }, _jsonSettings
            );
            await context.Response.WriteAsync(json);
        }
        catch (CountryUnauthorizedException cue)
        {
            context.Response.Clear();
            
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(
                new
                {
                    Message = cue.Message
                }, _jsonSettings);
            await context.Response.WriteAsync(json);
        }
        catch (Exception ex)
        {
            context.Response.Clear();

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(
                new
                {
                    Message = ex.Message
                }, _jsonSettings);
            await context.Response.WriteAsync(json);
        }
    }
}
 
public static class MiddlewareExceptionHandlerExtensions
{
    public static IApplicationBuilder UseMiddlewareExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MiddlewareExceptionHandler>();
    }
}