namespace Test.Payload;

public class User /*: BaseEntity*/
{
    public string Id { get; set; } = "A";
    public string? Name { get; set; } = null;
    public string? Family { get; set; } = null;
    public int Age { get; set; } = 10;
}