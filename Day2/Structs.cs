namespace Structs;

public interface IUser
{
    public string Name { get; set; }

    public int Age { get; set; }
}

public struct User : IUser
{
    public User()
    {
    }

    public string Name { get; set; }

    public int Age { get; set; }
}