using ReduxPelis.Models;

namespace ReduxPelis.Store.State
{
    public struct MovieState
    {
        public string Error { get; set; }
        public Movie[] Movies { get;set;}
        public Movie CurrentMovie { get; set; }
        public LoadStatus Status { get; set; }
    }
    public enum LoadStatus
    {
        None = 0,
        Loading,
        Loaded,
        Error
    }
}
