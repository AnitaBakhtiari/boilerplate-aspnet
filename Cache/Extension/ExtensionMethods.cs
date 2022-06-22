using System.Runtime.Serialization.Formatters.Binary;

namespace Cache.Extension;

public static class ExtensionMethods
{
    public static string ReplaceFirst(this string text, string search, string replace)
    {
        var pos = text.IndexOf(search, StringComparison.Ordinal);
        if (pos < 0) return string.Empty;
        return text[..pos] + replace + text[(pos + search.Length)..];
    }

    public static string FirstCharToUpper(this string input)
    {
        return input switch
        {
            null => string.Empty,
            "" => string.Empty,
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };
    }

    public static byte[] ObjectToByteArray(this object obj)
    {
        if (obj == null) return null!;

        var bf = new BinaryFormatter();
        var ms = new MemoryStream();
        bf.Serialize(ms, obj);

        return ms.ToArray();
    }

    public static object ByteArrayToObject(this byte[] arrBytes)
    {
        var memStream = new MemoryStream();
        var binForm = new BinaryFormatter();
        memStream.Write(arrBytes, 0, arrBytes.Length);
        memStream.Seek(0, SeekOrigin.Begin);
        var obj = binForm.Deserialize(memStream);

        return obj;
    }
}