namespace Project1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Sum(12, 58));
        Console.WriteLine("Enter your name:");
        var name = Console.ReadLine();
        Console.WriteLine("Enter your age:");
        var age = int.Parse(Console.ReadLine());

        Console.WriteLine($"Hello, {name}! Your age is {age}");
    }

    private static int Sum(int a, int b)
    {
        return a + b;
    }
}