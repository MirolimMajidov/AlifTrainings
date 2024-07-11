using System.Text;
using Day3Library;

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

        string mytext = string.Empty;
        StringBuilder myTextBuilder = new();
        for (int i = 0; i < 100; i++)
        {
            myTextBuilder.Append("Text");
        }
        mytext = myTextBuilder.ToString();

        var result1 = 12.Add(45);
        var result2 = result1.Multiply(45);
        
        var worker = new Worker();
        var salary = worker.CalculateSalary(28);
        var salary2 = IntegerExtenstion.CalculateSalary(worker, 15);
        
        Console.WriteLine($"Salary 1: {salary}");
        Console.WriteLine($"Salary 2: {salary2}");

        var myclass = new MyTestClass();
         var mm = myclass.Pro4;
    }
    
    private static void UpdateAge(ref Structs.User user)
    {
        user.Age *= 2;
    }
}