using AceLand.MementoService.Core;
using AceLand.MementoService.ProjectSetting;
using UnityEngine;

namespace AceLand.MementoService
{
    public partial class MementoService<T> : IMementoService<T>
    {
        private static AceLandMementoSettings Settings => Memento.Settings; 
        
        private readonly Originator<T> _originator = new();
        private readonly Caretaker<T> _caretaker = new();

        public int UndoCount => _caretaker.UndoCount;
        public int RedoCount => _caretaker.RedoCount;

        public void SaveState(T state)
        {
            _originator.SetState(state);
            _caretaker.AddMementoState(_originator.SaveToMemento());
            
            if (Settings.IsLogLevel) Debug.Log($"Saved Memento State : {typeof(T).Name}");
        }
        
        public bool TryUndo(out T state)
        {
            state = default;
            var mementoState = _caretaker.Undo();
            if (mementoState == null) return false;

            _originator.RestoreFromMemento(mementoState);
            state = _originator.GetState();
            
            if (Settings.IsLogLevel) Debug.Log($"Undo Memento State : {typeof(T).Name}");
            return true;
        }
        
        public bool TryRedo(out T state)
        {
            state = default;
            var mementoState = _caretaker.Redo();
            if (mementoState == null) return false;

            _originator.RestoreFromMemento(mementoState);
            state = _originator.GetState();
            
            if (Settings.IsLogLevel) Debug.Log($"Redo Memento State : {typeof(T).Name}");
            return true;
        }
        
        public void ClearHistory()
        {
            _caretaker.ClearHistory();
            if (Settings.IsLogLevel) Debug.Log($"Clear Memento History : {typeof(T).Name}");
        }
    }
}