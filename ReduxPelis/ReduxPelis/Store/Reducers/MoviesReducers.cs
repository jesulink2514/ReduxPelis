using Reducto;
using ReduxPelis.Actions;
using ReduxPelis.Models;
using ReduxPelis.State;

namespace ReduxPelis.Reducers
{
    public static class MoviesReducers
    {
        public static SimpleReducer<MovieState> All()
        {
            var reducer = new SimpleReducer<MovieState>()
                .When<LoadMoviesAction>((state, action) =>
                {
                    return new MovieState{
                        Error = string.Empty,
                        Movies = new Movie[0],
                        Status = LoadStatus.Loading
                    };
                })
                .When<LoadMoviesErrorAction>((state, action) =>
                {
                    return new MovieState
                    {
                        Error = action.Error,
                        Movies = new Movie[0],
                        Status = LoadStatus.Error
                    };
                })
                .When<LoadMoviesSuccessAction>((state, action) =>
                {
                    return new MovieState
                    {
                        Error = string.Empty,
                        Movies = action.Movies,
                        Status = LoadStatus.Loaded
                    };
                });

            return reducer;
        }
    }
}
