using AceLand.Library.Disposable;
using AceLand.MementoService.Core;
using UnityEngine;

namespace AceLand.MementoService
{
    public partial class MementoService<T> : DisposableObject
    {
        private MementoService()
        {
            _originator = new Originator<T>();
            _caretaker = new Caretaker<T>(Settings.HistoryLimit);
        }

        private MementoService(int historyLimit)
        {
            var limit = Mathf.Max(historyLimit, 4);
            _originator = new Originator<T>();
            _caretaker = new Caretaker<T>(limit);
        }

        internal static MementoService<T> Build() => new();

        internal static MementoService<T> Build(int historyLimit) => new(historyLimit);
        
        protected override void DisposeManagedResources()
        {
            _originator.Dispose();
            _caretaker.Dispose();
        }
    }
}