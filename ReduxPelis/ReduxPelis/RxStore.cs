using Reducto;
using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;

namespace ReduxPelis
{
    public class RxStore<TState> : Store<TState>, IDisposable
    {
        public RxStore(SimpleReducer<TState> rootReducer) : base(rootReducer)
        {
            SubscribeToStateChange();
        }

        public RxStore(CompositeReducer<TState> rootReducer) : base(rootReducer)
        {
            SubscribeToStateChange();
        }

        public RxStore(Reducer<TState> rootReducer) : base(rootReducer)
        {
            SubscribeToStateChange();
        }
        private Subject<TState> _stateChanged = new Subject<TState>();
        private Unsubscribe _sub;

        public IObservable<TState> AsObservable()
        {
            return _stateChanged;
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
