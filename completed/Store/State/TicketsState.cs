using ReduxPelis.Models;

namespace ReduxPelis.Store.State
{
    public struct TicketsState
    {
        public Ticket[] Tickets { get; set; }
        public LoadStatus Status { get; set; }
        public string Error { get; set; }
    }
}