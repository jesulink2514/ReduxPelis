using System;
using System.Collections.Generic;
using System.Text;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reducto;
using ReduxPelis.Navigation;
using ReduxPelis.Services;
using ReduxPelis.Store;
using ReduxPelis.Store.Actions;
using ReduxPelis.Store.Reducers;
using ReduxPelis.Store.State;
using ReduxPelis.ViewModels;

namespace ReduxPelis.Tests
{
    [TestClass]
    public class PremierePageViewModelTest
    {
        [TestMethod]
        public void OnAppearingShouldLoadMovies()
        {
            var store = A.Fake<IRxStore<AppState>>();
            var movieService = A.Fake<IMoviesService>();
            var nav = A.Fake<INavigationService>();

            var vm = new PremierePageViewModel(store,movieService,nav);

            vm.OnAppearing();

            A.CallTo(() => store.Dispatch(A<Store<AppState>.AsyncAction>._))
                .MustHaveHappenedOnceExactly();
        }
    }
}
