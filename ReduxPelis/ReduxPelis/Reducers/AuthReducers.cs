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
                .When<LoginStarted>((state, action) =>
                {
                    return new AuthState(LoginStatus.LoggedIn, action.Username, string.Empty);
                })
                .When<LoginSucceeded>((state, action) =>
                {
                    return new AuthState(LoginStatus.LoggedIn, state.UserName, action.Token);
                })
                .When<LoginFailed>((state, action) =>
                {
                    return new AuthState(LoginStatus.LoggedOut, state.UserName, state.Token);
                });

            return reducer;
        }
    }
}
