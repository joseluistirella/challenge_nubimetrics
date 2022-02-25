using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Service.Queries;
using Service.Repositories;

namespace Service.Handlers
{

    public class CreateUserHandler: IRequestHandler<CreateUser, User>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            
        }

        public async Task<User> Handle(CreateUser request, CancellationToken cancellation)
        {
            User user = this._mapper.Map<User>(request);
            return await this._repository.Save(user);
        }
    }

}