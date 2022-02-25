using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Service.Exceptions;
using Service.Queries;
using Service.Repositories;

namespace Service.Handlers
{

    public class GetCountryHandler: IRequestHandler<GetCountry, Country>
    {
        private readonly IMercadolibreRepository _repository;

        public GetCountryHandler(IMercadolibreRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Country> Handle(GetCountry request, CancellationToken cancellation)
        {
            string[] forbiddenCountries = new string[] {"CO", "BR"};
            
            // If the code is invalid throw a custom error exception.
            if(forbiddenCountries.Contains(request.Code.Trim().ToUpper()))
            {
                throw new CountryUnauthorizedException($"País '{request.Code}' no autorizado");               
            }

            return await this._repository.GetOneCountry(request.Code);
        }
    }

}