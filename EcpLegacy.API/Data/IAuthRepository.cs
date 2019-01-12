using System.Threading.Tasks;
using EcpLegacy.API.Models;

namespace EcpLegacy.API.Data
{
    public interface IAuthRepository
    {
        Task<Associate> Register(Associate associate, string password);
        Task<Associate> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}