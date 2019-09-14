using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReduxPelis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavPage
    {
        public NavPage(Page page):base(page)
        {
            InitializeComponent();
        }
        public NavPage()
        {
            InitializeComponent();
        }
    }
}