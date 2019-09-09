using System;
using System.Collections.Generic;
using System.Text;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReduxPelis.Actions;
using ReduxPelis.Reducers;
using ReduxPelis.Services;
using ReduxPelis.State;
using ReduxPelis.Store;
using ReduxPelis.Store.Actions;
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
            var store = new RxStore<AuthState>(AuthReducers.All());
            var loginService = A.Fake<ILoginService>();
            var viewModel = new LoginPageViewModel(store, loginService);

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
