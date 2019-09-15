using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reducto;
using ReduxPelis.Navigation;
using ReduxPelis.Reducers;
using ReduxPelis.Services;
using ReduxPelis.Store;
using ReduxPelis.Store.Actions;
using ReduxPelis.Store.State;
using ReduxPelis.ViewModels;

namespace ReduxPelis.Tests.ViewModels
{
    [TestClass]
    public class LoginViewModelTests
    {
        private IRxStore<AppState> _store;
        private ILoginService _loginService;
        private INavigationService _navService;
        private LoginPageViewModel _viewModel;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _store = new RxStore<AppState>(new CompositeReducer<AppState>()
                .Part(s => s.Auth, AuthReducers.All()));
            _loginService = A.Fake<ILoginService>();
            _navService = A.Fake<INavigationService>();
            _viewModel = new LoginPageViewModel(_store, _loginService, _navService);
        }

        [TestMethod]
        public void Given_LoginFailed_Then_ErrorMessage_ShowsUp()
        {
            //Arrange

            //Act
            _store.Dispatch(new LoginFailed {Error = "Fake error"});

            //Assert
            var hasError = _viewModel.HasError.Value;
            var message = _viewModel.ErrorMessage.Value;

            Assert.IsTrue(hasError);
            Assert.AreEqual("Fake error",message);
        }

        [TestMethod]
        public void Given_Invalid_User_Password_Navigation_Wont_Happened()
        {
            //Arrange
            A.CallTo(() => _loginService.GetTokenForUser(A<string>.Ignored, A<string>.Ignored))
                .Returns(Task.FromResult<TokenResponse>(new TokenResponse() {IsTokenError = true}));

            //Act
            _viewModel.LoginCommand.Execute();

            //Assert
            A.CallTo(() => _loginService.GetTokenForUser(_viewModel.User.Value, _viewModel.Password.Value))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _navService.GoToHome())
                .MustNotHaveHappened();
        }

        [TestMethod]
        public void Given_Valid_User_Password_Navigation_will_Happen()
        {
            //Arrange
            A.CallTo(() => _loginService.GetTokenForUser(A<string>.Ignored, A<string>.Ignored))
                .Returns(Task.FromResult<TokenResponse>(new TokenResponse() { IsTokenError = false, Token = "123"}));

            //Act
            _viewModel.LoginCommand.Execute();

            //Assert
            A.CallTo(() => _loginService.GetTokenForUser(_viewModel.User.Value, _viewModel.Password.Value))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _navService.GoToHome())
                .MustHaveHappenedOnceExactly();
        }

        [TestMethod]
        public void Given_InValid_User_Command_CannotBeExecute()
        {
            //Arrange
            _viewModel.User.Value = string.Empty;
            _viewModel.User.ForceValidate();

            //Act
            var canExecute = _viewModel.LoginCommand.CanExecute();

            //Assert
            Assert.IsFalse(canExecute);
        }

        [TestMethod]
        public void Given_InValid_Password_Command_CannotBeExecute()
        {
            //Arrange
            _viewModel.Password.Value = string.Empty;
            _viewModel.User.ForceValidate();

            //Act
            var canExecute = _viewModel.LoginCommand.CanExecute();

            //Assert
            Assert.IsFalse(canExecute);
        }
    }
}
