using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReduxPelis.Models;
using ReduxPelis.Navigation;
using ReduxPelis.Services;
using ReduxPelis.Store;
using ReduxPelis.Store.State;
using ReduxPelis.ViewModels;
using Xamarin.Forms;

namespace ReduxPelis.Tests.ViewModels
{
    [TestClass]
    public class MovieDetailsTest
    {
        private IRxStore<AppState> _store;
        private IMoviesService _moviesService;
        private INavigationService _navigationService;
        private MovieDetailsPageViewModel _vm;
        private BehaviorSubject<AppState> _subject;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _store = A.Fake<IRxStore<AppState>>();
            _moviesService = A.Fake<IMoviesService>();
            _navigationService = A.Fake<INavigationService>();
            _subject = new BehaviorSubject<AppState>(new AppState());
            var state = new AppState()
            {
                Movies = new MovieState
                {
                    CurrentMovie = new Movie
                    {
                        Id = Guid.NewGuid()
                    }
                }
            };

            A.CallTo(() => _store.AsObservable())
                .Returns(_subject);

            _vm = new MovieDetailsPageViewModel(_store,_moviesService,_navigationService);
        }

        [TestMethod]
        public void Given_StateChange_CurrentMovie_and_functions_get_loaded()
        {
            //Arrange
            var state = new AppState()
            {
                Movies = new MovieState
                {
                    CurrentMovie = new Movie
                    {
                        Id = Guid.NewGuid(),
                        Functions = new DateTime[]
                        {
                            DateTime.Now
                        }
                    }
                }
            };

            //Act
            _subject.OnNext(state);

            //Assert
            Assert.AreEqual(state.Movies.CurrentMovie.Id,_vm.CurrentMovie.Value.Id);
            Assert.AreEqual(state.Movies.CurrentMovie.Functions.Length, _vm.CurrentMovie.Value.Functions.Length);
        }
    }
}