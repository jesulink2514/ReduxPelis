using ReduxPelis.State;

namespace ReduxPelis.Store.State
{
    public struct AppState
    {
        public MovieState Movies;
        public AuthState Auth;
    }
}
