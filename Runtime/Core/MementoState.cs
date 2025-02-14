using AceLand.Library.Disposable;
using AceLand.Library.Extensions;

namespace AceLand.MementoService.Core
{
    internal class MementoState<T> : DisposableObject
    {
        private readonly T _state;

        public MementoState(T state) =>
            _state = state.DeepClone();

        public T GetState() =>
            _state.DeepClone();
    }
}