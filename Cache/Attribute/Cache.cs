namespace Cache.Attribute;

[AttributeUsage(AttributeTargets.All)]
public class Cache : System.Attribute
{
    public int Seconds { get; set; } = 30;
    public string Key { get; set; } = null!;
}