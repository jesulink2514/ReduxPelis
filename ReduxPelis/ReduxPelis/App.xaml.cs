using System.Diagnostics;
using Autofac;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reducto;
using ReduxPelis.DependencyInjection;
using ReduxPelis.Navigation;
using ReduxPelis.Reducers;
using ReduxPelis.State;
using ReduxPelis.Views;
using ReduxPelis.Store;
using ReduxPelis.Store.Actions;
using ReduxPelis.Store.Reducers;
using ReduxPelis.Store.State;
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

            Store = new RxStore<AppState>(new CompositeReducer<AppState>()
                .Part(s => s.Auth, AuthReducers.All())
                .Part(s => s.Movies, MoviesReducers.All()).Get());
            
            #if DEBUG
            Store.Middleware(store => next => action =>
            {
                var payload = JToken.Parse(JsonConvert.SerializeObject(action))
                    .ToString(Formatting.Indented);
                Debug.WriteLine($"action:{action.GetType()}==>{payload}");
                
                next(action);
                
                var state = JToken.Parse(JsonConvert.SerializeObject(store.GetState()))
                    .ToString(Formatting.Indented);
                Debug.WriteLine($"state:::{state}");
            });
            #endif
        }

        private void BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ApplicationModule());

            Container = builder.Build();
        }

        public static RxStore<AppState> Store { get; private set; }

        protected override void OnStart()
        {
            LoadState();

            var navService = Container.Resolve<INavigationService>();

            var state = Store.GetState().Auth;

            if (state.LoginStatus == LoginStatus.LoggedIn)
                navService.GoToHome();
            else
                navService.GoToLogin();
        }

        private async void SaveState()
        {
            var state = Store.GetState().Auth;
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

        public static T Resolve<T>() where T:class
        {
            return ((App)Application.Current)
                .Container.Resolve(typeof(T)) as T;
        }
    }
}
