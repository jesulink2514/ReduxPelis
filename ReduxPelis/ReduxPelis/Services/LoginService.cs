using System;
using System.Threading.Tasks;

namespace ReduxPelis.Services
{
    public class LoginService : ILoginService
    {
        public async Task<TokenResponse> GetTokenForUser(string user, string password)
        {
            await Task.Delay(2000);

            if (user != password)
                return new TokenResponse()
                {
                    Error = "User or password is incorrect.",
                    IsTokenError = true
                };

            var token = Guid.NewGuid().ToString();
            return new TokenResponse
            {
                Token = token, IsTokenError = false
            };
        }
    }
}