using AceLand.Library.BuildLeveling;
using AceLand.Library.ProjectSetting;
using UnityEngine;

namespace AceLand.MementoService.ProjectSetting
{
    public class AceLandMementoSettings : ProjectSettings<AceLandMementoSettings>
    {
        [Header("Settings")]
        [SerializeField] private MementoServiceType mementoServiceType = MementoServiceType.BackgroundAndLocal;
        [SerializeField] private BuildLevel logLevel = BuildLevel.Development;

        [Header("Storage Control")]
        [SerializeField, Min(4)] private int undoLimit = 32;
        [SerializeField, Min(4)] private int snapshotLimit = 64;
        
        public MementoServiceType MementoServiceType => mementoServiceType;
        public bool IsLogLevel => logLevel.IsAcceptedLevel();
        
        public int SnapshotLimit => snapshotLimit;
        public int UndoLimit => undoLimit;
    }
}