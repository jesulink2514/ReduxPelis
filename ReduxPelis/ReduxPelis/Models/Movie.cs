using System;
using System.ComponentModel;

namespace ReduxPelis.Models
{
    public class Movie: INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public DateTime[] Functions { get; set; } = new DateTime[0];

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
