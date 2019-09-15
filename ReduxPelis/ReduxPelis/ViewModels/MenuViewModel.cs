using System;
using System.ComponentModel;
using Reactive.Bindings;
using ReduxPelis.Navigation;

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

        public MenuViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
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

        private void Logout()
        {

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
