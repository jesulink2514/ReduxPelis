using Reducto;
using ReduxPelis.Models;
using ReduxPelis.Store.Actions;
using ReduxPelis.Store.State;

namespace ReduxPelis.Store.Reducers
{
    public static class TicketsReducers
    {
        public static SimpleReducer<TicketsState> All()
        {
            var reducer = new SimpleReducer<TicketsState>()
                .When<LoadTicketsAction>((s, a) => new TicketsState
                {
                    Error = null,
                    Tickets = new Ticket[0],
                    Status = LoadStatus.Loading
                })
                .When<LoadTicketsErrorAction>((s, a) => new TicketsState
                {
                    Error = a.Error,
                    Tickets = new Ticket[0],
                    Status = LoadStatus.Error
                })
                .When<LoadTicketsSuccessAction>((s, a) => new TicketsState
                {
                    Error = null,
                    Tickets = a.Tickets,
                    Status = LoadStatus.Loaded
                });

            return reducer;
        }
    }
}