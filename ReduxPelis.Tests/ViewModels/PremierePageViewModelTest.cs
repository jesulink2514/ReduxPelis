using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reducto;
using ReduxPelis.Models;
using ReduxPelis.Navigation;
using ReduxPelis.Services;
using ReduxPelis.Store;
using ReduxPelis.Store.Actions;
using ReduxPelis.Store.State;
using ReduxPelis.ViewModels;

namespace ReduxPelis.Tests.ViewModels
{
    [TestClass]
    public class PremierePageViewModelTest
    {
        private IRxStore<AppState> _store;
        private IMoviesService _movieService;
        private INavigationService _navigationService;
        private PremierePageViewModel _vm;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _store = A.Fake<IRxStore<AppState>>();
            _movieService = A.Fake<IMoviesService>();
            _navigationService = A.Fake<INavigationService>();
            UserDialogs.Instance = A.Fake<IUserDialogs>();
            _vm = new PremierePageViewModel(_store, _movieService, _navigationService);
        }

        [TestMethod]
        public async Task OnAppearingShouldLoadMovies()
        {
            //Arrange

            //Act
            await _vm.OnAppearingAsync();

            A.CallTo(() => _store.Dispatch(A<Store<AppState>.AsyncAction>._))
                .MustHaveHappenedOnceExactly();
        }

        [TestMethod]
        public void GoToCallsNavigateToDetails()
        {
            //Arrange
            var movie = new Movie
            {
                Id = Guid.NewGuid()
            };

            //Act
            _vm.GoToMovieCommand.Execute(movie);

            //Assert
            A.CallTo(() => _store.Dispatch(new SelectMovieAction(){SelectedMovie = movie}))
                .MustHaveHappenedOnceExactly();
            A.CallTo(() => _navigationService.GoToDetailsPage())
                .MustHaveHappenedOnceExactly();
        }
}
}
