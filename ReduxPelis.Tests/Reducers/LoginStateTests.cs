using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reducto;
using ReduxPelis.Reducers;
using ReduxPelis.Services;
using ReduxPelis.State;
using ReduxPelis.Store.Actions;
using ReduxPelis.Store.State;

namespace ReduxPelis.Tests.Reducers
{
    [TestClass]
    public class LoginStateTests
    {
        [TestMethod]
        public void Given_LoginStartDispatched_Then_LoginStatus_ShouldBe_LoginStarted()
        {
            // ReSharper disable once StringLiteralTypo
            const string user = "jesulink";
            var store = new Store<AuthState>(AuthReducers.All());
            var login = new StartLogin { Username = user };
            var expectedState = new AuthState(
                LoginStatus.LoginStarted,
                user,
                string.Empty);

            store.Dispatch(login);

            Assert.AreEqual(expectedState, store.GetState());
            Assert.AreEqual(expectedState.UserName, store.GetState().UserName);
            Assert.AreEqual(expectedState.Token, store.GetState().Token);
        }

        [TestMethod]
        public void Given_LoginErrorDispatched_Then_LoginStatus_ShouldBe_LoginError()
        {
            // ReSharper disable once StringLiteralTypo
            const string error = "login failed";
            var store = new Store<AuthState>(AuthReducers.All());
            var login = new LoginFailed { Error = error };
            var expectedState = new AuthState(
                LoginStatus.LoginError,
                null, 
                null,
                error);

            store.Dispatch(login);

            Assert.AreEqual(expectedState, store.GetState());
            Assert.AreEqual(expectedState.UserName, store.GetState().UserName);
            Assert.AreEqual(expectedState.Token, store.GetState().Token);
            Assert.AreEqual(expectedState.Error, store.GetState().Error);
        }

        [TestMethod]
        public async Task Given_LoginErrorDispatched_Then_LoginStatus_ShouldBe_LoginError_2()
        {
            var loginService = A.Fake<ILoginService>();
            A.CallTo(() =>
                    loginService.GetTokenForUser(A<string>._, A<string>._))
                .Returns(Task.FromResult(new TokenResponse
                {
                    Token = "token"
                }));

            var store = CreateStoreWithAuthReducers();

            var asyncAction = loginService.LoginAsync("jesus", "123456");
            await store.Dispatch(asyncAction);

            //Check status
            var state = store.GetState();

            Assert.AreEqual("token",state.Auth.Token);
        }

        private static Store<AppState> CreateStoreWithAuthReducers()
        {
            var store = new Store<AppState>(new CompositeReducer<AppState>()
                .Part(s => s.Auth, AuthReducers.All()));
            return store;
        }
    }
}