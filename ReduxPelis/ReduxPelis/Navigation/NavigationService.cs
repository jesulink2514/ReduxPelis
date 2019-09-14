using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReduxPelis.Models;
using ReduxPelis.Views;
using Xamarin.Forms;

namespace ReduxPelis.Navigation
{
    public interface INavigationService
    {
        Task GoToHome();
        Task GoToLogin();
        Task GoToDetailsPage();
    }
    public class NavigationService: INavigationService
    {
        public Task GoToHome()
        {
            Application.Current.MainPage = new NavPage(new HomePage());
            return Task.CompletedTask;
        }

        public Task GoToLogin()
        {
            Application.Current.MainPage = new LoginPage();
            return Task.CompletedTask;
        }

        public async Task GoToDetailsPage()
        {
            if(!(Application.Current.MainPage is NavigationPage nav)) return;
            await nav.Navigation.PushAsync(new DetailsPage());
        }
    }
}
