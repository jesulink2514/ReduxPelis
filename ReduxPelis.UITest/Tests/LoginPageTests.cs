using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ReduxPelis.UITest.Pages;
using Xamarin.UITest;

namespace ReduxPelis.UITest.Tests
{
    public class LoginPageTests : BaseTestFixture
    {
        public LoginPageTests(Platform platform) : base(platform)
        {
        }

        [Test]
        public void Repl()
        {
            if (TestEnvironment.IsTestCloud)
            {
                Assert.Ignore("REPL not enabled for UI Test");
                return;
            }
            app.Repl();
        }

        [Test]
        public void EnterInvalidCredentialsShowError()
        {
            var page = new LoginPage()
                .EnterUser("jesus")
                .EnterPassword("invalid-password");

            page.Login();

            var error = page.GetErrorMessage();

            Assert.IsNotEmpty(error);
        }

        [Test]
        public void EnterValidCredentialsNavigateToHome()
        {
            new LoginPage()
                .EnterUser("jesus")
                .EnterPassword("jesus")
                .Login();

            new HomePage();
        }

    }
}
