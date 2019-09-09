using Reducto;
using ReduxPelis.Actions;
using ReduxPelis.State;

namespace ReduxPelis.Reducers
{
    public static class AuthReducers
    {
        public static SimpleReducer<AuthState> All()
        {
            var reducer = new SimpleReducer<AuthState>()
                .When<StartLogin>((state, action) =>
                {
                    return new AuthState(LoginStatus.LoginStarted, action.Username, string.Empty);
                })
                .When<LoginSucceeded>((state, action) =>
                {
                    return new AuthState(LoginStatus.LoggedIn, state.UserName, action.Token);
                })
                .When<LoginFailed>((state, action) =>
                {
                    return new AuthState(LoginStatus.LoginError, state.UserName, state.Token, action.Error);
                })
                .When<LoadUser>((state, action) =>
                {
                    var status = string.IsNullOrEmpty(action.Token) ?
                        LoginStatus.None : 
                        LoginStatus.LoggedIn;

                    return new AuthState(status, action.Username, action.Token);
                });

            return reducer;
        }
    }
}
