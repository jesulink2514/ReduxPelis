using System;
using Reducto;
using ReduxPelis.Services;
using ReduxPelis.Store.State;

namespace ReduxPelis.Store.Actions
{
    public static class MoviesAction
    {
        public static Store<AppState>.AsyncAction GetLoadMoviesAsyncAction(
            this IMoviesService service,bool force = false)
        {
            return async (dispatch, getState) => {

                dispatch(new LoadMoviesAction{});

                //Not reload when is already loaded
                if (getState().Movies.Status == LoadStatus.Loaded && !force)
                    return;

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
            };
        }

        public static Store<AppState>.AsyncAction GetLoadTicketsAsyncAction(
            this IMoviesService service)
        {
            return async (dispatch, getState) => {

                dispatch(new LoadTicketsAction());

                //Not reload when is already loaded
                if (getState().Tickets.Status == LoadStatus.Loaded)
                    return;

                try
                {
                    var movies = await service.GetTickets();

                    var success = new LoadTicketsSuccessAction()
                    {
                        Tickets = movies
                    };

                    dispatch(success);
                }
                catch (Exception ex)
                {
                    var error = new LoadTicketsErrorAction()
                    {
                        Error = ex.Message
                    };
                    dispatch(error);
                }
            };
        }
    }
}