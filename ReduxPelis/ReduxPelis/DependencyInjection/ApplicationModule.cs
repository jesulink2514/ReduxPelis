﻿using Autofac;
using ReduxPelis.Navigation;
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

            builder.RegisterType<LoginService>()
                .As<ILoginService>()
                .SingleInstance();

            builder.RegisterType<NavigationService>()
                .As<INavigationService>()
                .SingleInstance();
        }
    }
}
