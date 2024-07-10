namespace Records;

public record User
{
    public string FirstName { get; set; }
}

public record Student : User
{
    public string Name { get; set; }

    public int Age { get; set; }
}