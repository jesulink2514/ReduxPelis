using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxPelis.Actions
{
    public struct LoginStarted
    {
        public string Username;
    }

    public struct LoginFailed { }

    public struct LoginSucceeded
    {
        public string Token;
    }
}
