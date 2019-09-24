using Autofac;
using ReduxPelis.Navigation;
using ReduxPelis.Services;
using ReduxPelis.State;
using ReduxPelis.Store;
using ReduxPelis.Store.State;
using ReduxPelis.ViewModels;

namespace ReduxPelis.DependencyInjection
{
    public class ApplicationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MoviesService>()
                .As<IMoviesService>()
                .SingleInstance();

            builder.RegisterType<LoginService>()
                .As<ILoginService>()
                .SingleInstance();

            builder.RegisterType<LoginPageViewModel>();
            builder.RegisterType<PremierePageViewModel>();
            builder.RegisterType<MovieDetailsPageViewModel>();
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<TicketsPageViewModel>();

            builder.Register(c => App.Store)
                .As<IRxStore<AppState>>()
                .SingleInstance();

            builder.RegisterType<NavigationService>()
                .As<INavigationService>()
                .SingleInstance();
        }
    }
}
