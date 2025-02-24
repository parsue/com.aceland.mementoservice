namespace AceLand.MementoService.Global
{
    internal class GlobalMementoService
    {
        private GlobalMementoService()
        {
            globalMemento = Memento.BuildLocalService<GlobalMementoState>();
        }

        internal static GlobalMementoService Build() => new GlobalMementoService();
        
        private readonly MementoService<GlobalMementoState> globalMemento;
        internal int UndoCount => globalMemento.UndoCount;
        internal int RedoCount => globalMemento.RedoCount;

        private GlobalMementoState _currentState;

        internal void SaveState<T>(T state) where T : GlobalMementoState
        {
            if (UndoCount == 0 && RedoCount == 0)
                globalMemento.SaveState(state);
            
            state.OnBeforeSave();
            globalMemento.SaveState(state);
            _currentState = state;
        }

        internal void Undo()
        {
            if (globalMemento.UndoCount == 0) return;
            _currentState?.OnStateUndo();
            var state = globalMemento.Undo();
            _currentState = state;
        }

        internal void Redo()
        {
            if (globalMemento.RedoCount == 0) return;
            var state = globalMemento.Redo();
            state?.OnStateRedo();
            _currentState = state;
        }

        internal void ClearHistory()
        {
            globalMemento.ClearHistory();
            _currentState = null;
        }
    }
}