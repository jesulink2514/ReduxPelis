using System;
using Reducto;
using ReduxPelis.Services;
using ReduxPelis.Store.State;

namespace ReduxPelis.Store.Actions
{
    public static class AuthActions
    {
        public static Store<AppState>.AsyncAction<TokenResponse> LoginAsync(
            this ILoginService service,
            string user, string password)
        {
            return async (dispatch, getState) => {

                dispatch(new StartLogin{Username = user});

                try
                {
                    var token = await service.GetTokenForUser(user,password);
                    if (token.IsTokenError)
                    {
                        var error = new LoginFailed
                        {
                            Error = token.Error
                        };
                        dispatch(error);
                    }
                    else
                    {
                        var loginSucceed = new LoginSucceeded
                        {
                            Token = token.Token
                        };
                        dispatch(loginSucceed);
                    }

                    return token;
                }
                catch (Exception ex)
                {
                    var error = new LoginFailed
                    {
                        Error = ex.Message
                    };
                    dispatch(error);

                    return new TokenResponse{IsTokenError = true, Error = "generic error"};
                }
            };
        }
    }
}