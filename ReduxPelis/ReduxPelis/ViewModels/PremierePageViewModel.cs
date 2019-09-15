using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Reactive.Bindings;
using ReduxPelis.Models;
using ReduxPelis.Navigation;
using ReduxPelis.Services;
using ReduxPelis.Store;
using ReduxPelis.Store.Actions;
using ReduxPelis.Store.State;
using Xamarin.Forms;

namespace ReduxPelis.ViewModels
{
    public class PremierePageViewModel : INotifyPropertyChanged, INavigatedAware
    {
        private readonly IRxStore<AppState> _store;
        private readonly IMoviesService _service;
        private readonly INavigationService _navigationService;

        public ReadOnlyReactiveProperty<Movie[]> Movies { get; private set; }

        public ICommand GoToMovieCommand { get; private set; }

        public PremierePageViewModel(
            IRxStore<AppState> store,
            IMoviesService service,
            INavigationService navigationService)
        {
            _store = store;
            _service = service;
            _navigationService = navigationService;

            Movies = _store.AsObservable().Select(x => x.Movies)
                .Select(x => x.Movies)
                .ToReadOnlyReactiveProperty();

            GoToMovieCommand = new Command(OnGoToMovie);
        }

        private async void OnGoToMovie(object obj)
        {
            if(obj == null)return;
            if (obj is Movie movie)
            {
                _store.Dispatch(new SelectMovieAction {SelectedMovie = movie});
                await _navigationService.GoToDetailsPage();
            }
        }

        public async void OnAppearing(object param=null)
        {
            await OnAppearingAsync();
        }

        public async Task OnAppearingAsync()
        {
            var loadAction = _service.GetLoadMoviesAsyncAction();
            using (UserDialogs.Instance.Loading())
            {
                await _store.Dispatch(loadAction);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
