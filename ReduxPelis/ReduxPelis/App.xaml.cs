using Reducto;
using ReduxPelis.Reducers;
using ReduxPelis.State;
using Xamarin.Forms;

namespace ReduxPelis
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Store = new RxStore<AuthState>(AuthReducers.All());            
        }

        public static RxStore<AuthState> Store{get;private set;}

        protected override void OnStart()
        {
            MainPage = new MainPage();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
