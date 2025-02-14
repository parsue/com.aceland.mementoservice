using AceLand.Library.Editor.Providers;
using AceLand.MementoService.ProjectSetting;
using UnityEditor;
using UnityEngine.UIElements;

namespace AceLand.MementoService.Editor.ProjectSettingsProvider
{
    public class MementoServiceSettingsProvider : AceLandSettingsProvider
    {
        public const string SETTINGS_NAME = "Project/AceLand Packages/Memento Service";
        
        [InitializeOnLoadMethod]
        public static void CreateSettings() => AceLandMementoSettings.GetSerializedSettings();
        
        private MementoServiceSettingsProvider(string path, SettingsScope scope = SettingsScope.User) 
            : base(path, scope) { }
        
        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            Settings = AceLandMementoSettings.GetSerializedSettings();
        }

        [SettingsProvider]
        public static SettingsProvider CreateMyCustomSettingsProvider()
        {
            var provider = new MementoServiceSettingsProvider(SETTINGS_NAME, SettingsScope.Project);
            return provider;
        }
    }
}