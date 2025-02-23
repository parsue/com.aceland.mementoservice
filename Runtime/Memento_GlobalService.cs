using System;
using AceLand.MementoService.Global;
using AceLand.MementoService.ProjectSetting;

namespace AceLand.MementoService
{
    public static partial class Memento
    {
        private static GlobalMementoService _service;

        public static int GlobalUndoCount => _service.UndoCount;
        public static int GlobalRedoCount => _service.RedoCount;

        public static void SaveGlobalState<T>(T state) where T : GlobalMementoState
        {
            CheckServiceLevel();
            _service.SaveState(state);
        }

        public static void UndoGlobalState()
        {
            CheckServiceLevel();
            _service.Undo();
        }

        public static void RedoGlobalState()
        {
            CheckServiceLevel();
            _service.Redo();
        }
        
        public static void ClearGlobalHistory()
        {
            CheckServiceLevel();
            _service.ClearHistory();
        }

        private static void CheckServiceLevel()
        {
            if (Settings.MementoServiceMode is not MementoServiceMode.LocalOnly) return;
            throw new Exception($"Memento Service Deny: Service Type is {Settings.MementoServiceMode.ToName()}. " +
                                $"Please change the Memento Service Type to {MementoServiceMode.GlobalAndLocal.ToName()}.");
        }
    }
}