using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Samat.Framework.Domain;
public static class EnumExtensions
{
    public static string GetEnumName(this Enum? enumType)
    {
        return enumType.GetType().GetMember(enumType.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DisplayAttribute>()
            .Name ?? "";
    }
}
