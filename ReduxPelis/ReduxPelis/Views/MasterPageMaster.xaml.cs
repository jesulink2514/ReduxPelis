using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using ReduxPelis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using MenuItem = ReduxPelis.ViewModels.MenuItem;

namespace ReduxPelis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPageMaster
    {
        public MasterPageMaster()
        {
            InitializeComponent();
            //BindingContext = App.Resolve<MenuViewModel>();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            //this.Menu.SelectedItem = null;
            //if (BindingContext is MenuViewModel vm)
            //{
            //    var menu = e.Item as MenuItem;
            //    vm.GoToCommand.Execute(menu);
            //}
        }
    }
}