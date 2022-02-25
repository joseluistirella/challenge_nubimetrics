using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Service.Queries;
using Service.Repositories;

namespace Service.Handlers
{

    public class SearchItemsHandler: IRequestHandler<SearchItems, Search>
    {
        private readonly IMercadolibreRepository _repository;

        public SearchItemsHandler(IMercadolibreRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Search> Handle(SearchItems request, CancellationToken cancellation)
        {
            return await this._repository.Search(request.Query);
        }
    }

}