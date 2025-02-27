using AceLand.MementoService.Global;
using AceLand.MementoService.ProjectSetting;
using UnityEngine;

namespace AceLand.MementoService
{
    public static partial class Memento
    {
        internal static AceLandMementoSettings Settings
        {
            get
            {
                _settings ??= Resources.Load<AceLandMementoSettings>(nameof(AceLandMementoSettings));
                return _settings;
            }
        }
        
        private static AceLandMementoSettings _settings;

        internal static void Initialization()
        {
            Debug.Log($"Memento Service Mode : {Settings.MementoServiceMode.ToName()}");
            
            if (Settings.MementoServiceMode is MementoServiceMode.LocalOnly) return;

            _service = GlobalMementoService.Build();
            Debug.Log($"Memento Background Service is Ready");
        }

        public static MementoService<T> BuildLocalService<T>() where T : IMementoState =>
            MementoService<T>.Build();

        public static MementoService<T> BuildLocalService<T>(int historyLimit) where T : IMementoState =>
            MementoService<T>.Build(historyLimit);
    }
}