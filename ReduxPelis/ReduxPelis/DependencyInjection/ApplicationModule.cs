using Autofac;
using ReduxPelis.Services;

namespace ReduxPelis.DependencyInjection
{
    public class ApplicationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MoviesService>()
                .As<IMoviesService>()
                .SingleInstance();
        }
    }
}
