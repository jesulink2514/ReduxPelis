using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace ReduxPelis.UITest.Pages
{
    public class LoginPage: BasePage
    {
        private Query UserQuery => p => p.Marked("TxtUser");
        private Query PasswordQuery => p => p.Marked("TxtPassword");
        private Query LoginButtonQuery => p => p.Marked("BtnLogin");
        public Query ErrorMessageQuery => p => p.Marked("Error");
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TxtUser"),
            iOS = x => x.Marked("TxtUser")
        };

        public LoginPage EnterUser(string user)
        {
            app.EnterText(UserQuery,user);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            app.EnterText(PasswordQuery,password);
            return this;
        }

        public void Login()
        {
            app.Tap(LoginButtonQuery);
        }

        public string GetErrorMessage()
        {
            app.WaitForElement(ErrorMessageQuery);
            var error = app.Query(ErrorMessageQuery).FirstOrDefault()?.Text;
            return error;
        }
    }
}
