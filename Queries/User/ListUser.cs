using System.Collections.Generic;

using MediatR;

namespace Service.Queries
{

    public class ListUser: IRequest<List<User>>
    {
        public ListUser(string id)
        {
            this.Id = id;
        }

        public string Id { set; get; }


    }

}