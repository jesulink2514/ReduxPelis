using System.Diagnostics;
using Autofac;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reducto;
using ReduxPelis.DependencyInjection;
using ReduxPelis.Navigation;
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
        }

        private void BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ApplicationModule());

            Container = builder.Build();
        }

        protected override void OnStart()
        {
            var navService = Container.Resolve<INavigationService>();    
            navService.GoToLogin();
        }


        protected override void OnSleep()
        {
            
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
