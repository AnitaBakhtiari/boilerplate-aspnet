using System.ComponentModel;
using System.Reflection;

namespace Http.Helper.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum e)
    {
        var attribute =
            e.GetType()
                    .GetTypeInfo()
                    .GetMember(e.ToString())
                    .FirstOrDefault(member => member.MemberType == MemberTypes.Field)!
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault()
                as DescriptionAttribute;

        return attribute?.Description ?? e.ToString();
    }

    public static T ToEnum<T>(this string input)
    {
        return (T) Enum.Parse(typeof(T), input, true);
    }
}