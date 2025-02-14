using System.Text.RegularExpressions;

namespace AceLand.MementoService.ProjectSetting
{
    public enum MementoServiceType
    {
        BackgroundAndLocal,
        LocalOnly,
    }

    internal static class MementoServiceTypeExtension
    {
        public static string ToName(this MementoServiceType mementoServiceType) =>
            Regex.Replace(mementoServiceType.ToString(), "(?<!^)([A-Z])", " $1");
    } 
}