using Xamarin.Forms.Xaml;

namespace ReduxPelis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage
    {
        public DetailsPage()
        {
            InitializeComponent();
            //BindingContext = App.Resolve<MovieDetailsPageViewModel>();
        }
    }
}