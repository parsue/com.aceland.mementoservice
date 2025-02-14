using AceLand.Library.Disposable;

namespace AceLand.MementoService
{
    public partial class MementoService<T> : DisposableObject
    {
        private MementoService() { }

        internal static MementoService<T> Build() => new MementoService<T>();
        
        protected override void DisposeManagedResources()
        {
            _originator.Dispose();
            _caretaker.Dispose();
        }
    }
}