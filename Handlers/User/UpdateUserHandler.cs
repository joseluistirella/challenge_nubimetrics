using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Service.Queries;
using Service.Repositories;

namespace Service.Handlers
{

    public class UpdateUserHandler: IRequestHandler<UpdateUser, User>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            
        }

        public async Task<User> Handle(UpdateUser request, CancellationToken cancellation)
        {
            User user = this._mapper.Map<User>(request);
            return await this._repository.Save(user);
        }
    }

}