﻿using System;
using AceLand.MementoService.Core;
using AceLand.MementoService.ProjectSetting;
using UnityEngine;

namespace AceLand.MementoService
{
    public partial class MementoService<T> : IMementoService<T>
        where T : IMementoState
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

        public T Redo()
        {
            var mementoState = _caretaker.Redo();
            if (mementoState == null)
                throw new Exception($"No recovered Memento state for type {typeof(T).Name}. Please check RedoCount before Redo, or use TryRedo method.");
            
            _originator.RestoreFromMemento(mementoState);
            if (Settings.IsLogLevel) Debug.Log($"Redo Memento State : {typeof(T).Name}");
            return _originator.GetState();
        }
        
        public void ClearHistory()
        {
            _caretaker.ClearHistory();
            if (Settings.IsLogLevel) Debug.Log($"Clear Memento History : {typeof(T).Name}");
        }
    }
}