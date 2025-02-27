using AceLand.Library.Disposable;

namespace AceLand.MementoService.Core
{
    internal class Originator<T> : DisposableObject
        where T : IMementoState
    {
        private T _state;

        public void SetState(T state)
        {
            _state = state;
        }

        public T GetState()
        {
            return _state;
        }

        public InternalMementoState<T> SaveToMemento()
        {
            return new InternalMementoState<T>(_state);
        }

        public void RestoreFromMemento(InternalMementoState<T> internalMemento)
        {
            _state = internalMemento.GetState();
        }
    }
}