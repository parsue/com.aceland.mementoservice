using AceLand.Library.Editor;
using AceLand.MementoService.ProjectSetting;
using UnityEditor;

namespace AceLand.MementoService.Editor.Drawer
{
    [CustomEditor(typeof(AceLandMementoSettings))]
    public class MementoServiceSettingInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorHelper.DrawAllPropertiesAsDisabled(serializedObject);
        }
    }
}