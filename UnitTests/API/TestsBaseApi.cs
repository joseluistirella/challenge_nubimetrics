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


public class TestsBaseApi
{

    protected readonly HttpClient _client;

    public TestsBaseApi()
    {
        var appFactory = new WebApplicationFactory<Program>();
        this._client = appFactory.CreateClient();        
    }

    
}



