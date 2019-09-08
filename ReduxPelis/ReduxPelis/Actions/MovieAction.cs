using ReduxPelis.Models;
using ReduxPelis.Services;
using System;
using static Reducto.Store<ReduxPelis.State.MovieState>;

namespace ReduxPelis.Actions
{
    public struct LoadMoviesAction
    {
    }

    public struct LoadMoviesErrorAction
    {
        public string Error { get; set; }
    }

    public struct LoadMoviesSuccessAction
    {
        public Movie[] Movies { get;set;}
    }

    public static class MoviesAction
    {
        public static AsyncAction GetLoadMoviesAsyncAction(this IMoviesService service)
        {
            return new AsyncAction(async (dispatch, getState) => {

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
