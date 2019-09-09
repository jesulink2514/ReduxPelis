using System.Threading.Tasks;

namespace ReduxPelis.Services
{
    public interface ILoginService
    {
        Task<TokenResponse> GetTokenForUser(string user, string password);
    }
}