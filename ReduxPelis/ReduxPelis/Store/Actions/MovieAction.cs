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
}
