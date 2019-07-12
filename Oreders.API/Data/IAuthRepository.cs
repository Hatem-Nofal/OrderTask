using System.Threading.Tasks;
using Oreders.API.Models;

namespace Oreders.API.Models {
    public interface IAuthRepository {
        Task<User> Register (User user, string password);
        Task<User> Login (string username, string password);
        Task<bool> UserExists (string username);

    }
}