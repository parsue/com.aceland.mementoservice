using System.Text.RegularExpressions;

namespace AceLand.MementoService.ProjectSetting
{
    public enum MementoServiceMode
    {
        GlobalAndLocal,
        LocalOnly,
    }

    internal static class MementoServiceTypeExtension
    {
        public static string ToName(this MementoServiceMode mementoServiceMode) =>
            Regex.Replace(mementoServiceMode.ToString(), "(?<!^)([A-Z])", " $1");
    } 
}