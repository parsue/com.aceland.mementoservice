using AceLand.Library.Disposable;

namespace AceLand.MementoService.Core
{
    internal class Originator<T> : DisposableObject
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

        public MementoState<T> SaveToMemento()
        {
            return new MementoState<T>(_state);
        }

        public void RestoreFromMemento(MementoState<T> memento)
        {
            _state = memento.GetState();
        }
    }
}