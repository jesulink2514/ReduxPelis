using System;
using System.Collections.Generic;
using System.Text;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reducto;
using ReduxPelis.Navigation;
using ReduxPelis.Reducers;
using ReduxPelis.Services;
using ReduxPelis.State;
using ReduxPelis.Store;
using ReduxPelis.Store.Actions;
using ReduxPelis.Store.State;
using ReduxPelis.ViewModels;

namespace ReduxPelis.Tests
{
    [TestClass]
    public class LoginViewModelTests
    {
        [TestMethod]
        public void Given_LoginFailed_Then_ErrorMessage_ShowsUp()
        {
            //Arrange
            var store = new RxStore<AppState>(new CompositeReducer<AppState>()
                .Part(s=>s.Auth,AuthReducers.All()));
            var loginService = A.Fake<ILoginService>();
            var navService = A.Fake<INavigationService>();
            var viewModel = new LoginPageViewModel(store, loginService,navService);

            //Act
            store.Dispatch(new LoginFailed {Error = "Fake error"});

            //Assert
            var hasError = viewModel.HasError.Value;
            var message = viewModel.ErrorMessage.Value;

            Assert.IsTrue(hasError);
            Assert.AreEqual("Fake error",message);
        }
    }
}
