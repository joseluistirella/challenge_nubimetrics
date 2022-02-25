using Moq;
using Service.Repositories;

namespace Service.Mocks
{
    public static class MockMercadolibreRepository
    {
        public static Mock<IMercadolibreRepository> GetCountryMercadolibreRepository()
        {
            var country = new Country("CO", "Colombia", "es_CO", "COP", ",", ".", "GMT-05:00", 
                new GeoInformation(new Location(1, 1)), 
                new System.Collections.Generic.List<State>()
                {
                    new State("TUNPUEFUTG9mNDk5", "Atlántico"),
                    new State("TUNPUENBUWExNjM3MA", "Caqueta"),
                    new State("TUNPUE1BR2FiZjQ0", "Magdalena")
                }
            );
            
            var mockRepo = new Mock<IMercadolibreRepository>();
            mockRepo.Setup(r => r.GetOneCountry("CO")).ReturnsAsync(country);
            
            return mockRepo;

        }

    } 

}