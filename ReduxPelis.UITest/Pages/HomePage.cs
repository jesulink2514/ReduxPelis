using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace ReduxPelis.UITest.Pages
{
    public class HomePage : BasePage
    {
        public Query LogoutButtonQuery = x => x.Marked("LogoutBtn");
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = p => p.Id("navigationBarBackground"),
            iOS = p => p.Marked("")
        };

        public void ChooseMovie(int index = 0)
        {
            if (OnAndroid)
            {
                app.Tap(x => x.Class("ItemContentView").Index(index));
            }
            else
            {

            }
        }

        public HomePage OpenMenu()
        {
            app.DragCoordinates(0,100,800,100);
            return this;
        }

        public HomePage CloseMenu()
        {
            app.DragCoordinates(700, 100, 0, 100);
            return this;
        }

        public HomePage Logout()
        {
            app.Tap(LogoutButtonQuery);
            return this;
        }
    }
}