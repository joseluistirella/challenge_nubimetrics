using System.Collections.Generic;
using System.Threading.Tasks;

using Service.Queries;

namespace Service.Repositories
{
    
    public interface IUserRepository
    {

        Task<List<User>> Get(string id);

        Task Delete(string id);
       
        Task<User> Save(User persistUser);
        
    }
}
