using System;
using System.ComponentModel;
using System.Reactive.Linq;
using Acr.UserDialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using ReduxPelis.Models;
using ReduxPelis.Navigation;
using ReduxPelis.Services;
using ReduxPelis.Store;
using ReduxPelis.Store.Actions;
using ReduxPelis.Store.State;

namespace ReduxPelis.ViewModels
{
    public class TicketsPageViewModel :
        INavigatedAware,
        INotifyPropertyChanged
    {
        private readonly IMoviesService _moviesService;
        private readonly IRxStore<AppState> _store;
        public string Test { get; set; }

        public TicketsPageViewModel(
            IMoviesService moviesService,
            IRxStore<AppState> store)
        {
            _moviesService = moviesService;
            _store = store;

            Tickets = store.AsObservable()
                .Select(x => x.Tickets)
                .Select(x => x.Tickets)
                .ToReadOnlyReactiveProperty();

            TestCommand = new ReactiveCommand();

            TestCommand.Subscribe(() => { Test = Guid.NewGuid().ToString().Replace("-", ""); });
        }

        public ReactiveCommand TestCommand { get; set; }

        public ReadOnlyReactiveProperty<Ticket[]> Tickets { get; private set; }

        public async void OnAppearing(object param = null)
        {
            using (UserDialogs.Instance.Loading())
            {
                var action = _moviesService.GetLoadTicketsAsyncAction();
                await _store.Dispatch(action);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}