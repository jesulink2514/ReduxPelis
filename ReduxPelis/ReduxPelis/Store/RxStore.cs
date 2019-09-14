using System;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Reducto;
using ReduxPelis.Navigation;

namespace ReduxPelis.Store
{
    public class RxStore<TState> : Store<TState>, IRxStore<TState>
    {
 
        public RxStore(SimpleReducer<TState> rootReducer) : base(rootReducer)
        {
            _stateChanged = new BehaviorSubject<TState>(GetState());
            SubscribeToStateChange();
        }

        public RxStore(CompositeReducer<TState> rootReducer) : base(rootReducer)
        {
            _stateChanged = new BehaviorSubject<TState>(GetState());
            SubscribeToStateChange();
        }

        public RxStore(Reducer<TState> rootReducer) : base(rootReducer)
        {
            _stateChanged = new BehaviorSubject<TState>(GetState());
            SubscribeToStateChange();
        }
        private readonly BehaviorSubject<TState> _stateChanged;

        private Unsubscribe _sub;
        
        public IObservable<TState> AsObservable()
        {
            return _stateChanged.AsObservable();
        }

        private void SubscribeToStateChange()
        {
            _sub = this.Subscribe(s => _stateChanged.OnNext(s));
        }

        public void Dispose()
        {
            _sub();
        }
    }
}
