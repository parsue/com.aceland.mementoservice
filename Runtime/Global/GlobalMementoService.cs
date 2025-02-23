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

        internal void SaveState<T>(T state) where T : GlobalMementoState
        {
            state.OnBeforeSave();
            globalMemento.SaveState(state);
        }

        internal void Undo()
        {
            if (globalMemento.UndoCount == 0) return;
            var state = globalMemento.Undo();
            state.OnStateChanged();
        }

        internal void Redo()
        {
            if (globalMemento.RedoCount == 0) return;
            var state = globalMemento.Redo();
            state.OnStateChanged();
        }

        internal void ClearHistory()
        {
            globalMemento.ClearHistory();
        }
    }
}