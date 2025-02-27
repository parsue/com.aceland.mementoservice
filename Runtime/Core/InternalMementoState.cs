using AceLand.Library.Disposable;

namespace AceLand.MementoService.Core
{
    internal class InternalMementoState<T> : DisposableObject
        where T : IMementoState
    {
        private readonly T _state;

        public InternalMementoState(T state) => _state = (T)state.Clone();
        public T GetState() => (T)_state.Clone();
    }
}