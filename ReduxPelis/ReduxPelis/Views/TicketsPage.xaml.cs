using Xamarin.Forms.Xaml;

namespace ReduxPelis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketsPage
    {
        public TicketsPage()
        {
            InitializeComponent();
            //BindingContext = App.Resolve<TicketsPageViewModel>();
        }

        protected override void OnAppearing()
        {
            //if (BindingContext is INavigatedAware vm)
            //{
            //    vm.OnAppearing();
            //}
        }
    }
}