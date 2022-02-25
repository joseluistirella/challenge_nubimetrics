using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Service.Queries;
using Service.Repositories;

namespace Service.Handlers
{

    public class ListUserHandler: IRequestHandler<ListUser, List<User>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public ListUserHandler(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            
        }

        public async Task<List<User>> Handle(ListUser query, CancellationToken cancellation)
        {
            List<User> list = await this._repository.Get(query.Id);
            return list;
        }
    }

}