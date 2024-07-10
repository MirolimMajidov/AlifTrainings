using Classes.SubClasses;

namespace Day2;

internal class Program
{
    private static void Main(string[] args)
    {
        var user = new Structs.User();
        user.Name = "Jake";
        user.Age = 19;
        UpdateAge(ref user);
        Console.WriteLine($"Hello, {user.Age}!");
    }


    private static void UpdateAge(ref Structs.User user)
    {
        user.Age *= 2;
    }
}