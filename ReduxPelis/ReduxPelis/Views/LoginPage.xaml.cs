using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReduxPelis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //BindingContext = App.Resolve<LoginPageViewModel>();
        }
    }
}