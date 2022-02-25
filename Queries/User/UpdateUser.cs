using MediatR;

namespace Service.Queries
{

    public class UpdateUser: IRequest<User>
    {
        
        
        public string Id { get; set; }  

        public string Nombre { get; set; }

        public string Apellido  { get; set; }

        public string Email { get; set; }
        
        public string Password  { get; set; }
        
     
    }

}