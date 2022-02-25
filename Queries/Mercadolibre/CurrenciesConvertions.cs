using MediatR;

namespace Service.Queries
{

    public class CurrenciesConvertions: IRequest<string>
    {
        public CurrenciesConvertions()
        {
        }
    }

}