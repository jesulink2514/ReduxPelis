using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxPelis.State
{
    
    public struct AuthState
    {
        public AuthState(
            LoginStatus loginStatus, 
            string userName, 
            string token,
            string error=null)
        {
            LoginStatus = loginStatus;
            UserName = userName;
            Token = token;
            Error = error;
        }

        public LoginStatus LoginStatus { get; }
        public string UserName { get; }
        public string Token { get; }
        public string Error { get; set; }
    }

    public enum LoginStatus
    {
        None,
        LoginStarted,
        LoggedIn,
        LoginError,
        LoggedOut
        
    }
}
