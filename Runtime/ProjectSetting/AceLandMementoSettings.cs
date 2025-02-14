using AceLand.Library.BuildLeveling;
using AceLand.Library.ProjectSetting;
using UnityEngine;

namespace AceLand.MementoService.ProjectSetting
{
    public enum MementoServiceType
    {
        LongTermAndIndependent,
        IndependentOnly,
    }
    
    public class AceLandMementoSettings : ProjectSettings<AceLandMementoSettings>
    {
        [Header("Settings")]
        [SerializeField] private MementoServiceType mementoServiceType = MementoServiceType.LongTermAndIndependent;
        [SerializeField] private BuildLevel logLevel = BuildLevel.Development;

        [Header("Storage Control")]
        [SerializeField] private int snapshotLimit = 64;
        [SerializeField] private int undoPerObjectLimit = 32;
    }
}