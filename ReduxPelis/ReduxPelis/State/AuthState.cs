using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxPelis.State
{
    public class AuthState
    {
        public AuthState(LoginStatus loginStatus, string userName, string token)
        {
            LoginStatus = loginStatus;
            UserName = userName;
            Token = token;
        }

        public LoginStatus LoginStatus { get; }
        public string UserName { get; }
        public string Token { get; }
    }

    public enum LoginStatus
    {
        LoggedIn,
        InvalidUser,
        LoggedOut,
        None
    }
}
