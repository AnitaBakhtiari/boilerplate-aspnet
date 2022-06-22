using System.Text.RegularExpressions;

namespace OAuth_Keycloak.Extensions;

public static class StringExtension
{
    public static string ReplaceNameTags<T>(this string str, T arguments)
    {
        var result = str;
        var properties = arguments?.GetType().GetProperties();

        if (properties == null) return result;

        foreach (var prop in properties)
        {
            var propValue = prop.GetValue(arguments, null);
            if (propValue is null) continue;
            result = Regex.Replace(result, $"{{{prop.Name}}}", propValue.ToString() ?? string.Empty,
                RegexOptions.IgnoreCase);
        }

        return result;
    }
}