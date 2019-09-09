using Autofac;
using ReduxPelis.Services;
using ReduxPelis.State;
using ReduxPelis.Store;
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

            builder.Register(c => App.Store)
                .As<IRxStore<AuthState>>()
                .SingleInstance();
        }
    }
}
