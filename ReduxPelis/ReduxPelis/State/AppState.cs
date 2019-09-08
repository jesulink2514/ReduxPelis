using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxPelis.State
{
    public class AppState
    {
        public MovieState Movies { get; set; } = new MovieState();
        public AuthState Auth { get; set; } = new AuthState(LoginStatus.None,"","");
    }
}
