using MediatR;

namespace Service.Queries
{

    public class DeleteUser: IRequest<bool>
    {
        public DeleteUser(string id)
        {
            this.Id = id;
        }

        public string Id { set; get; }

    }

}