[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public sealed class MyCustomAttribute : Attribute
{
    public string Role1 { get; }
    public string Role2 { get; }

    public MyCustomAttribute(string role1, string role2)
    {
        Role1 = role1;
        Role2 = role2;
    }
}
