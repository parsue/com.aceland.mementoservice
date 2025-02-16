using AceLand.Library.BuildLeveling;
using AceLand.Library.ProjectSetting;
using UnityEngine;

namespace AceLand.MementoService.ProjectSetting
{
    public class AceLandMementoSettings : ProjectSettings<AceLandMementoSettings>
    {
        [Header("Settings")]
        [SerializeField] private MementoServiceMode mementoServiceMode = MementoServiceMode.GlobalAndLocal;
        [SerializeField, Min(4)] private int historyLimit = 32;
        [SerializeField] private BuildLevel logLevel = BuildLevel.Development;
        
        public MementoServiceMode MementoServiceMode => mementoServiceMode;
        public int HistoryLimit => historyLimit;
        public bool IsLogLevel => logLevel.IsAcceptedLevel();
    }
}