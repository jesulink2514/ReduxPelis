using System;
using System.Reactive.Linq;
using Acr.UserDialogs;
using Newtonsoft.Json;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using ReduxPelis.Models;
using ReduxPelis.Navigation;
using ReduxPelis.Services;
using ReduxPelis.Store;
using ReduxPelis.Store.State;
using Xamarin.Forms;

namespace ReduxPelis.ViewModels
{
    public class MovieDetailsPageViewModel
    {
        private readonly IRxStore<AppState> _store;
        private readonly IMoviesService _moviesService;
        private readonly INavigationService _navigationService;

        public MovieDetailsPageViewModel(
            IRxStore<AppState> store,
            IMoviesService moviesService,
            INavigationService navigationService)
        {
            _store = store;
            _moviesService = moviesService;
            _navigationService = navigationService;

            CurrentMovie = _store.AsObservable()
                .Select(x => x.Movies.CurrentMovie)
                .ToReadOnlyReactiveProperty(mode: ReactivePropertyMode.RaiseLatestValueOnSubscribe);

            Functions = _store.AsObservable().Select(x => x.Movies)
                .Where(x => x.CurrentMovie != null)
                .Select(x => x.CurrentMovie.Functions)
                .ToReadOnlyReactiveProperty();

            BuyTicketCommand = new[] {Function.SetValidateNotifyError(f => f == null ? "You should pick a function" : null)
                .ObserveHasErrors}
                .CombineLatestValuesAreAllFalse()
                .ToReactiveCommand();

            BuyTicketCommand.Subscribe(OnBuyTicket);
        }

        private async void OnBuyTicket()
        {
            var response = await Application.Current.MainPage
                .DisplayAlert("Buy", "Are you sure?",
                    "Yes", "No");

            if (response && Function.Value.HasValue)
            {
                using (UserDialogs.Instance.Loading())
                {
                    await _moviesService.BuyTicketFor(CurrentMovie.Value.Id, Function.Value.Value);
                }
                await _navigationService.GoToTicketPage();
            }
        }

        public ReactiveCommand BuyTicketCommand { get; private set; }

        public ReactiveProperty<DateTime?> Function { get; private set; } = new ReactiveProperty<DateTime?>();

        public ReadOnlyReactiveProperty<DateTime[]> Functions { get; set; }

        public ReadOnlyReactiveProperty<Movie> CurrentMovie { get; set; }
    }
}
