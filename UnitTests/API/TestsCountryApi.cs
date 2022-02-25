using System;
using Xunit;
using Moq;
using Service;
using Service.Repositories;
using Service.Mocks;
using Service.Handlers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

using System.Threading.Tasks;

namespace UnitTests;


public class TestsCountryApi: TestsBaseApi
{


    public TestsCountryApi(): base()
    {
    }

    
    [Fact]
    public async Task GetCountries()
    {
        var response = await this._client.GetAsync("/Paises/AR");
        System.Console.WriteLine(response);
        return;
    }

}



