using System;
using Reducto;
using ReduxPelis.Services;
using ReduxPelis.State;

namespace ReduxPelis.Actions
{
    public static class MoviesAction
    {
        public static Store<MovieState>.AsyncAction GetLoadMoviesAsyncAction(this IMoviesService service)
        {
            return new Store<MovieState>.AsyncAction(async (dispatch, getState) => {

                dispatch(new LoadMoviesAction{});

                try
                {
                    var movies = await service.GetAvailableMovies();

                    var success = new LoadMoviesSuccessAction
                    {
                        Movies = movies
                    };

                    dispatch(success);
                }
                catch (Exception ex)
                {
                    var error = new LoadMoviesErrorAction
                    {
                        Error = ex.Message
                    };
                    dispatch(error);
                }
            });
        }
    }
}