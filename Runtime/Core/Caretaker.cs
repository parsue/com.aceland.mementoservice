using System.Collections.Generic;
using System.Linq;
using AceLand.Library.Disposable;
using UnityEngine;

namespace AceLand.MementoService.Core
{
    internal class Caretaker<T> : DisposableObject
        where T : IMementoState
    {
        public Caretaker(int historyLimit) =>
            this.historyLimit = historyLimit; 
        
        private Stack<InternalMementoState<T>> _undoStack = new();
        private readonly Stack<InternalMementoState<T>> _redoStack = new();
        private readonly int historyLimit;
        
        public int UndoCount => Mathf.Max(_undoStack.Count - 1, 0);
        public int RedoCount => _redoStack.Count;

        protected override void DisposeManagedResources()
        {
            ClearHistory();
        }

        public void AddMementoState(InternalMementoState<T> internalMemento)
        {
            _undoStack.Push(internalMemento);
            _redoStack.Clear();

            if (_undoStack.Count <= historyLimit) return;
            
            _undoStack = new Stack<InternalMementoState<T>>(_undoStack.Reverse().Skip(1));
        }
        
        public InternalMementoState<T> Undo()
        {
            if (_undoStack.Count < 0) return null;

            var currentState = _undoStack.Pop();
            _redoStack.Push(currentState);

            return _undoStack.Peek();
        }

        public InternalMementoState<T> Redo()
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