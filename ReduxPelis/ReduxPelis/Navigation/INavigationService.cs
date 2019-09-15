using System.Threading.Tasks;

namespace ReduxPelis.Navigation
{
    public interface INavigationService
    {
        Task GoToHome();
        Task GoToLogin();
        Task GoToDetailsPage();
        Task GoToTicketPage();
    }
}