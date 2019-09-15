using System.Threading.Tasks;
using ReduxPelis.Views;
using Xamarin.Forms;

namespace ReduxPelis.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task GoToHome()
        {
            Application.Current.MainPage = new
                MasterPage()
            {
                Detail = new NavPage(new HomePage())
            };
            return Task.CompletedTask;
        }

        public Task GoToLogin()
        {
            Application.Current.MainPage = new LoginPage();
            return Task.CompletedTask;
        }

        public async Task GoToDetailsPage()
        {
            if (!(Application.Current.MainPage is MasterPage master)) return;
            if (!(master.Detail is NavPage nav)) return;
            await nav.Navigation.PushAsync(new DetailsPage());
        }

        public async Task GoToTicketPage()
        {
            if (!(Application.Current.MainPage is MasterPage master)) return;
            if (!(master.Detail is NavPage nav)) return;
            if(nav.CurrentPage is TicketsPage)return;
            await nav.Navigation.PushAsync(new TicketsPage());
        }
    }
}
