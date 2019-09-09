using System.ComponentModel;
using System.Reactive.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using ReduxPelis.Actions;
using ReduxPelis.Services;
using ReduxPelis.State;
using ReduxPelis.Store;

namespace ReduxPelis.ViewModels
{
    public class LoginPageViewModel: INotifyPropertyChanged
    {
        public ReactiveProperty<string> User { get; private set; }
        public ReactiveProperty<string> Password { get; private set; }
        public ReadOnlyReactiveProperty<string> ErrorMessage{ get; private set; }
        public ReadOnlyReactiveProperty<bool> IsLoading { get; private set; }
        public ReadOnlyReactiveProperty<bool> HasError { get; private set; }
        public ReactiveCommand LoginCommand { get; private set; }

        public LoginPageViewModel(
            IRxStore<AuthState> store,
            ILoginService loginService)
        {
            User = new ReactiveProperty<string>("")
                .SetValidateNotifyError(x => string.IsNullOrEmpty(x) ? "Invalid value" : null); ;
            Password = new ReactiveProperty<string>("")
                .SetValidateNotifyError(x => string.IsNullOrEmpty(x) ? "Invalid value" : null); ;

            var validateObservable = new[] {User.ObserveHasErrors, User.ObserveHasErrors}
                .CombineLatestValuesAreAllFalse();

            var isNotLoading = store.AsObservable()
                .Select(s => s.LoginStatus != LoginStatus.LoginStarted);

            LoginCommand = validateObservable.Merge(isNotLoading)
                .ToReactiveCommand()
                .WithSubscribe(async() =>
                {
                    var loginAction = loginService.LoginAsync(User.Value, Password.Value);
                     await store.Dispatch(loginAction);
                });

            IsLoading = store.AsObservable()
                .Select(s => s.LoginStatus == LoginStatus.LoginStarted)
                .ToReadOnlyReactiveProperty();

            ErrorMessage = store.AsObservable()
                .Select(s => s.Error).ToReadOnlyReactiveProperty();

            HasError = store.AsObservable()
                .Select(s => s.LoginStatus == LoginStatus.LoginError)
                .ToReadOnlyReactiveProperty();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
