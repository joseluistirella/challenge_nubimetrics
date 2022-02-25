using MediatR;

namespace Service.Queries
{

    public class SearchItems: IRequest<Search>
    {
        public SearchItems(string query)
        {
            this.Query = query;
        }

        public string Query { set; get; }

    }

}