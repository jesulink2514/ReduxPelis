using System;
using System.ComponentModel;

namespace ReduxPelis.Models
{
    public class Ticket : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public Movie Movie { get; set; }
        public DateTime Function { get; set; }
        public string TicketData { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}