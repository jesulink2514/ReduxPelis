using ReduxPelis.Models;

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
}
