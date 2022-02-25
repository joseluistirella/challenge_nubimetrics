using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Service.Queries
{


    public class User: IUser
    {
        public User()
        {
            
        }

        public User(string id, string nombre, string apellido, string email, string password)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Password = password;
            
        }
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 

        public string Nombre { get; set; }

        public string Apellido  { get; set; }

        public string Email { get; set; }
        
        public string Password  { get; set; }

    }

    public interface IUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; } 

        string Nombre { get; set; }

        string Apellido  { get; set; }

        string Email { get; set; }
        
        string Password  { get; set; }

    }


}