using ReduxPelis.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxPelis.State
{
    public class MovieState
    {
        public string Error { get; set; }
        public Movie[] Movies { get;set;} = new Movie[0];
        public Movie CurrentMovie { get; set; }
        public LoadStatus Status { get; set; } = LoadStatus.None;
    }
    public enum LoadStatus
    {
        Loading,
        Loaded,
        Error,
        None
    }
}
