using System;
using AceLand.MementoService.Core;
using AceLand.MementoService.ProjectSetting;
using UnityEngine;

namespace AceLand.MementoService
{
    public partial class MementoService<T> : IMementoService<T>
    {
        private static AceLandMementoSettings Settings => Memento.Settings; 
        
        private readonly Originator<T> _originator;
        private readonly Caretaker<T> _caretaker;

        public int UndoCount => _caretaker.UndoCount;
        public int RedoCount => _caretaker.RedoCount;

        public void SaveState(T state)
        {
            _originator.SetState(state);
            _caretaker.AddMementoState(_originator.SaveToMemento());
            
            if (Settings.IsLogLevel) Debug.Log($"Saved Memento State : {typeof(T).Name}");
        }

        public T Undo()
        {
            var mementoState = _caretaker.Undo();
            if (mementoState == null)
                throw new Exception($"No recovered Memento state for type {typeof(T).Name}. Please check UndoCount before Undo, or use TryUndo method.");
            
            _originator.RestoreFromMemento(mementoState);
            if (Settings.IsLogLevel) Debug.Log($"Undo Memento State : {typeof(T).Name}");
            return _originator.GetState();
        }
        
        public bool TryUndo(out T state)
        {
            var mementoState = _caretaker.Undo();
            if (mementoState == null)
            {
                state = default;
                return false;
            }

            _originator.RestoreFromMemento(mementoState);
            state = _originator.GetState();
            
            if (Settings.IsLogLevel) Debug.Log($"Undo Memento State : {typeof(T).Name}");
            return true;
        }

        public T Redo()
        {
            var mementoState = _caretaker.Redo();
            if (mementoState == null)
                throw new Exception($"No recovered Memento state for type {typeof(T).Name}. Please check RedoCount before Redo, or use TryRedo method.");
            
            _originator.RestoreFromMemento(mementoState);
            if (Settings.IsLogLevel) Debug.Log($"Redo Memento State : {typeof(T).Name}");
            return _originator.GetState();
        }
        
        public bool TryRedo(out T state)
        {
            var mementoState = _caretaker.Redo();
            if (mementoState == null)
            {
                state = default;
                return false;
            }

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