using MediatR;

namespace Service.Queries
{

    public class GetCountry: IRequest<Country>
    {
        public GetCountry(string code)
        {
            this.Code = code;
        }

        public string Code { set; get; }

    }

}