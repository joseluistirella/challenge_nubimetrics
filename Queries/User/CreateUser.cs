using MediatR;

namespace Service.Queries
{

    public class CreateUser: IRequest<User>
    {

        public string Nombre { get; set; }

        public string Apellido  { get; set; }

        public string Email { get; set; }
        
        public string Password  { get; set; }

    }

}