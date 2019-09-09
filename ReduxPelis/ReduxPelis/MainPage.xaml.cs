using Reactive.Bindings;
using ReduxPelis.Actions;
using ReduxPelis.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReduxPelis.Store.Actions;
using Xamarin.Forms;

namespace ReduxPelis
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ReactiveProperty<string> User { get; private set; }

        public ReadOnlyReactiveProperty<string> UserCaps { get; private set; }
        public ReactiveCommand SetUserCommand {get;}
        public MainPage()
        {
            InitializeComponent();            

            User = App.Store.AsObservable()
                .Select(x=> x.UserName)
                .DistinctUntilChanged()
                .ToReactiveProperty(string.Empty);

            UserCaps = User.Throttle(TimeSpan.FromMilliseconds(800))                
                .Select(x=> this.ToUpperInService(x).ToObservable())                
                .Switch()
                .ToReadOnlyReactiveProperty(string.Empty);

            SetUserCommand = new ReactiveCommand();

            SetUserCommand.Subscribe(()=> App.Store.Dispatch(new StartLogin{Username="jesus"}));

            UserCaps.Subscribe(s=> {Debug.Write(s);});

            this.BindingContext = this;
        }

        private async Task<string> ToUpperInService(string user)
        {
            await Task.Delay(2000);
            return user?.ToUpper();
        }
    }
}
