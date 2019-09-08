using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxPelis.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
    }
}
