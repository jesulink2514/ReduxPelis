using ReduxPelis.Models;

namespace ReduxPelis.Store.Actions
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

    public struct SelectMovieAction
    {
        public Movie SelectedMovie { get; set; }
    }

    public struct LoadTicketsAction
    {
    }

    public struct LoadTicketsErrorAction
    {
        public string Error { get; set; }
    }

    public struct LoadTicketsSuccessAction
    {
        public Ticket[] Tickets { get; set; }
    }
}
