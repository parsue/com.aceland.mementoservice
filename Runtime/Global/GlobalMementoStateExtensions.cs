namespace AceLand.MementoService.Global
{
    public static class GlobalMementoStateExtensions
    {
        public static void SaveGlobalState<T>(this T state) where T : GlobalMementoState =>
            Memento.SaveGlobalState(state);
    }
}