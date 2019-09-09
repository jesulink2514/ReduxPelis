using System.Diagnostics;
using Autofac;
using Newtonsoft.Json;
using ReduxPelis.Actions;
using ReduxPelis.DependencyInjection;
using ReduxPelis.Reducers;
using ReduxPelis.State;
using ReduxPelis.Views;
using ReduxPelis.Store;
using ReduxPelis.Store.Actions;
using Xamarin.Forms;

namespace ReduxPelis
{
    public partial class App : Application
    {
        public IContainer Container { get;private set;}
        public App()
        {
            InitializeComponent();

            BuildContainer();

            Store = new RxStore<AuthState>(AuthReducers.All());
            
            #if DEBUG
            Store.Middleware(store => next => action =>
            {
                Debug.WriteLine(JsonConvert.SerializeObject(action));
                next(action);
                Debug.WriteLine(JsonConvert.SerializeObject(store.GetState()));
            });
            #endif
        }

        private void BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ApplicationModule());

            Container = builder.Build();
        }

        public static RxStore<AuthState> Store { get; private set; }

        protected override void OnStart()
        {
            LoadState();

            var state = Store.GetState();

            MainPage = state.LoginStatus == LoginStatus.LoggedIn ? 
                new HomePage() as Page: 
                new LoginPage();
        }

        private async void SaveState()
        {
            var state = Store.GetState();
            Properties["user"] = state.UserName;
            Properties["token"] = state.Token;
            await SavePropertiesAsync();
        }

        private void LoadState()
        {
            var initState = new LoadUser
            {
                Username = "",
                Token = ""
            };

            if (Properties.ContainsKey("user"))
            {
                var user = Properties["user"]?.ToString();
                var token = Properties["token"]?.ToString();
                initState = new LoadUser
                {
                    Username = user,
                    Token = token
                };
            }
            Store.Dispatch(initState);
        }

        protected override void OnSleep()
        {
            SaveState();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
