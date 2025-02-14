using System;
using System.Collections.Generic;
using AceLand.MementoService.Core;
using AceLand.MementoService.ProjectSetting;

namespace AceLand.MementoService
{
    public static partial class Memento
    {
        private static Dictionary<Type, IMementoService> _mementoServices;

        public static int UndoCount<T>()
        {
            CheckServiceLevel();
            var t = typeof(T);
            return _mementoServices.TryGetValue(t, out var mementoService) ? mementoService.UndoCount : 0;
        }

        public static int RedoCount<T>()
        {
            CheckServiceLevel();
            var t = typeof(T);
            return _mementoServices.TryGetValue(t, out var mementoService) ? mementoService.RedoCount : 0;
        }

        public static void SaveState<T>(T state)
        {
            CheckServiceLevel();
            var t = typeof(T);
            if (!_mementoServices.TryGetValue(t, out var mementoService))
            {
                mementoService = BuildLocalService<T>();
                _mementoServices[t] = mementoService;
            }
            if (mementoService is not IMementoService<T> service) return;
            
            service.SaveState(state);
        }
        
        public static bool TryUndo<T>(out T state)
        {
            CheckServiceLevel();
            state = default;
            var t = typeof(T);
            if (!_mementoServices.TryGetValue(t, out var mementoService)) return false;
            return mementoService is IMementoService<T> service && service.TryUndo(out state);
        }
        
        public static bool TryRedo<T>(out T state)
        {
            CheckServiceLevel();
            state = default;
            var t = typeof(T);
            if (!_mementoServices.TryGetValue(t, out var mementoService)) return false;
            return mementoService is IMementoService<T> service && service.TryRedo(out state);
        }
        
        public static void ClearHistory<T>()
        {
            CheckServiceLevel();
            var t = typeof(T);
            if (!_mementoServices.Remove(t, out var mementoService)) return;
            mementoService.Dispose();
        }

        private static void CheckServiceLevel()
        {
            if (Settings.MementoServiceType is not MementoServiceType.LocalOnly) return;
            throw new Exception($"Memento Service Deny: Service Type is {Settings.MementoServiceType.ToName()}. " +
                                $"Please change the Memento Service Type to {MementoServiceType.BackgroundAndLocal.ToName()}.");
        }
    }
}