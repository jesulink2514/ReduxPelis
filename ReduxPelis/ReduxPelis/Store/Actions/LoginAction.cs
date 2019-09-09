using System.Collections.Generic;
using System.Text;

namespace ReduxPelis.Actions
{
    public struct StartLogin
    {
        public string Username;
    }

    public struct LoginFailed
    {
        public string Error;
    }

    public struct LoginSucceeded
    {
        public string Token;
    }

    public struct LoadUser
    {
        public string Username;
        public string Token;
    }
}
