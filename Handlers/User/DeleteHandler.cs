using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Service.Queries;
using Service.Repositories;

namespace Service.Handlers
{

    public class DeleteUserHandler: IRequestHandler<DeleteUser, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public DeleteUserHandler(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<bool> Handle(DeleteUser query, CancellationToken cancellation)
        {
            await this._repository.Delete(query.Id);
            return true;
        }
    }

}