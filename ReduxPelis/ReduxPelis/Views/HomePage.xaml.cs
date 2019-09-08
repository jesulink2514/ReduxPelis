
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReduxPelis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
        }
    }
}