namespace AceLand.MementoService.Core
{
    public interface IMementoService
    {
        int UndoCount { get; }
        int RedoCount { get; }
        void ClearHistory();
        void Dispose();
    }
    
    public interface IMementoService<T> : IMementoService
    {
        void SaveState(T state);
        T Undo();
        T Redo();
    }
}