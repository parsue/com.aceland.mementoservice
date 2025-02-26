using System.Collections.Generic;
using System.Linq;
using AceLand.Library.Disposable;
using UnityEngine;

namespace AceLand.MementoService.Core
{
    internal class Caretaker<T> : DisposableObject
    {
        public Caretaker(int historyLimit) =>
            this.historyLimit = historyLimit; 
        
        private Stack<MementoState<T>> _undoStack = new();
        private readonly Stack<MementoState<T>> _redoStack = new();
        private readonly int historyLimit;
        
        public int UndoCount => Mathf.Max(_undoStack.Count - 1, 0);
        public int RedoCount => _redoStack.Count;

        protected override void DisposeManagedResources()
        {
            ClearHistory();
        }

        public void AddMementoState(MementoState<T> memento)
        {
            _undoStack.Push(memento);
            _redoStack.Clear();

            if (_undoStack.Count <= historyLimit) return;
            
            _undoStack = new Stack<MementoState<T>>(_undoStack.Reverse().Skip(1));
        }
        
        public MementoState<T> Undo()
        {
            if (_undoStack.Count <= 0) return null;

            var currentState = _undoStack.Pop();
            _redoStack.Push(currentState);

            return _undoStack.Peek();
        }

        public MementoState<T> Redo()
        {
            if (_redoStack.Count == 0) return null;

            var mementoState = _redoStack.Pop();
            _undoStack.Push(mementoState);

            return mementoState;
        }
        
        public void ClearHistory()
        {
            foreach (var state in _undoStack)
                state.Dispose();
            _undoStack.Clear();
            
            foreach (var state in _redoStack)
                state.Dispose();
            _redoStack.Clear();
        }
    }
}