using Reducto;
using ReduxPelis.Models;
using ReduxPelis.Store.Actions;
using ReduxPelis.Store.State;

namespace ReduxPelis.Store.Reducers
{
    public static class MoviesReducers
    {
        public static SimpleReducer<MovieState> All()
        {
            var reducer = new SimpleReducer<MovieState>()
                .When<LoadMoviesAction>((state, action) =>
                {
                    return new MovieState
                    {
                        Error = string.Empty,
                        Movies = new Movie[0],
                        Status = LoadStatus.Loading
                    };
                })
                .When<LoadMoviesErrorAction>((state, action) => new MovieState
                {
                    Error = action.Error,
                    Movies = new Movie[0],
                    Status = LoadStatus.Error
                })
                .When<LoadMoviesSuccessAction>((state, action) => new MovieState
                {
                    Error = string.Empty,
                    Movies = action.Movies,
                    Status = LoadStatus.Loaded
                })
                .When<SelectMovieAction>((state,action)=> new MovieState
                {
                    Error = state.Error,
                    Movies = state.Movies,
                    CurrentMovie = action.SelectedMovie,
                    Status = state.Status
                });

            return reducer;
        }
    }
}
