using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using Service.Queries;
using Service.Repositories;
using Service.Mocks;
using Service.Handlers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace UnitTests;


public class TestsUserApi: TestsBaseApi
{


    public TestsUserApi(): base() 
    {

        List<User> usersToCreate = new()
        {
            new User(null, "Juan", "Perez", "juan.perez@gmail.com", GetSecurityCode().ToString()),
            new User(null, "Fernando", "Gago", "fernando.gago@gmail.com", GetSecurityCode().ToString()),
            new User(null, "Ezequiel", "Palacios", "ezequiel.palacios@gmail.com", GetSecurityCode().ToString()),
            new User(null, "Marcelo", "Gallardo", "marcelo.gallardo@gmail.com", GetSecurityCode().ToString())
        };

        foreach (User u in usersToCreate)
        {
            string json = JsonConvert.SerializeObject(u);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = _client.PostAsync("/User", content).Result;
        }
            
    }

    private int GetSecurityCode()
    {
        Random random = new Random(); 
        return random.Next(9999, 99999);
    }

    
    [Fact]
    public async Task GetUser()
    {
        var response = await this._client.GetAsync("/User");
        System.Console.WriteLine(response);
        return;
    }

}



