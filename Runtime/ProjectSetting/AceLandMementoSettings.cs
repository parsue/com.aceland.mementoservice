using AceLand.Library.BuildLeveling;
using AceLand.Library.ProjectSetting;
using UnityEngine;
using UnityEngine.Serialization;

namespace AceLand.MementoService.ProjectSetting
{
    public class AceLandMementoSettings : ProjectSettings<AceLandMementoSettings>
    {
        [Header("Settings")]
        [SerializeField] private MementoServiceMode mementoServiceMode = MementoServiceMode.GlobalAndLocal;
        [SerializeField, Min(4)] private int undoLimit = 32;
        [SerializeField] private BuildLevel logLevel = BuildLevel.Development;
        
        public MementoServiceMode MementoServiceMode => mementoServiceMode;
        public int UndoLimit => undoLimit;
        public bool IsLogLevel => logLevel.IsAcceptedLevel();
    }
}