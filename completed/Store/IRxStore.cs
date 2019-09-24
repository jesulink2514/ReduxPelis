using System;
using System.Threading.Tasks;
using Reducto;

namespace ReduxPelis.Store
{
    public interface IRxStore<TState> : IBasicStore<TState>, IDisposable
    {
        Task<TResult> Dispatch<TResult>(Store<TState>.AsyncAction<TResult> action);
        Task Dispatch(Store<TState>.AsyncAction action);
        IObservable<TState> AsObservable();
    }
}