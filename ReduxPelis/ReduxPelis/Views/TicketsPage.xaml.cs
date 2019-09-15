using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReduxPelis.Navigation;
using ReduxPelis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReduxPelis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketsPage
    {
        public TicketsPage()
        {
            InitializeComponent();
            BindingContext = App.Resolve<TicketsPageViewModel>();
        }

        protected override void OnAppearing()
        {
            if (BindingContext is INavigatedAware vm)
            {
                vm.OnAppearing();
            }
        }
    }
}