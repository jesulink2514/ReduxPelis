using System;
using System.ComponentModel;
using Reactive.Bindings;
using ReduxPelis.Navigation;
using ReduxPelis.Store;
using ReduxPelis.Store.Actions;
using ReduxPelis.Store.State;

namespace ReduxPelis.ViewModels
{
    public enum MenuOptions
    {
        Premiere,
        Tickets
    }
    public class MenuItem
    {
        public string Description { get; set; }
        public MenuOptions Option { get; set; }
    }
    public class MenuViewModel: INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private readonly IRxStore<AppState> _store;

        public MenuViewModel(
            INavigationService navigationService,
            IRxStore<AppState> store)
        {
            _navigationService = navigationService;
            _store = store;
            Menus = new[]
            {
                new MenuItem{Description = "Premiere",Option = MenuOptions.Premiere}, 
                new MenuItem{Description = "Tickets",Option = MenuOptions.Tickets} 
            };
            GoToCommand = new ReactiveCommand<MenuItem>();
            LogoutCommand = new ReactiveCommand();

            GoToCommand.Subscribe(OnGoTo);
            LogoutCommand.Subscribe(Logout);
        }

        public ReactiveCommand<MenuItem> GoToCommand { get; private set; }
        public ReactiveCommand LogoutCommand { get; private set; }
        public MenuItem[] Menus { get; private set; }

        private async void Logout()
        {
            _store.Dispatch(new StartLogout { });
            await _navigationService.GoToLogin();
        }
        private async void OnGoTo(MenuItem menu)
        {
            switch (menu.Option)
            {
                case MenuOptions.Premiere:
                    await _navigationService.GoToHome();
                    break;
                case MenuOptions.Tickets:
                    await _navigationService.GoToTicketPage();
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
