using System;
using Xunit;
using Moq;
using Service.Queries;
using Service.Repositories;
using Service.Mocks;
using Service.Handlers;

using System.Threading.Tasks;
using Service.Exceptions;

namespace UnitTests;


public class GetCountryHandlersTests
{
    private readonly Mock<IMercadolibreRepository> _mockRepo;

    public GetCountryHandlersTests()
    {
        _mockRepo = MockMercadolibreRepository.GetCountryMercadolibreRepository();
    }

    [Fact]
    public async void GetCountryHandlerTest()
    {
        var handler = new GetCountryHandler(_mockRepo.Object);
        var result = handler.Handle(new GetCountry("AR"), System.Threading.CancellationToken.None);

        await Assert.ThrowsAsync<CountryUnauthorizedException>(async() => await handler.Handle(new GetCountry("CO"), System.Threading.CancellationToken.None));
    }
}



