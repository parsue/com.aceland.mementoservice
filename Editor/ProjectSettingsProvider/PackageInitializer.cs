using AceLand.MementoService.ProjectSetting;
using UnityEditor;

namespace AceLand.MementoService.Editor.ProjectSettingsProvider
{
    [InitializeOnLoad]
    public static class PackageInitializer
    {
        static PackageInitializer()
        {
            AceLandMementoSettings.GetSerializedSettings();
        }
    }
}