using System.Collections.Concurrent;

namespace Day5;

class Program
{
    static void Main(string[] args)
    {
        //int[] items1 = [1, 221, 32, 41];
        var items2 = new List<int> { 1, 221, 32, 41 };
        items2.Add(23);
        // items2.AddRange([27, 3, 232]);
        // foreach (var item in items2)
        // {
        //     Console.WriteLine(item);
        // }

        var items4 = new ConcurrentDictionary<string, int>();

        // var items3 = new Dictionary<string, int>()
        // {
        //     {"Jamshed", 23},
        //     {"Rahmatillo", 56},
        //     {"Shodiyor", 67},
        //     {"Ahmat", 12},
        //     {"Rahmat", 34},
        // };
        // items3.Add("Ali", 89);

        //
        // if (items3.ContainsKey("YourId"))
        // {
        //     //Your logic
        // }
        //
        // //foreach (var item in items3)
        // foreach (var (key, value) in items3)
        // {
        //     Console.WriteLine($"Key: {key}, value:{value}");
        // }

        // int[] items6 = [1, 221, 32, 41];
        // Span<int> items8 = [1, 221, 32, 41];
        // Span<int> items7 = items6.AsSpan();
        // foreach (var item in items7)
        // {
        //     Console.WriteLine(item);
        // }

        // Queue<int> items9 = new Queue<int>();
        // items9.Enqueue(12);
        // items9.Enqueue(34);
        // items9.Enqueue(23);
        //
        // var item = items9.Dequeue();
        // foreach (var _item in items9)
        // {
        //     Console.WriteLine(_item);
        // }

        // Stack<int> items10 = new Stack<int>();
        // items10.Push(23);
        // items10.Push(45);
        // var item = items10.Pop();

        // HashSet<string> items11 = new();
        // items11.Add("Ali");
        // items11.Add("Jamshed");
        // items11.Add("Suhrob");
        // items11.Add("Alisher");
        // foreach (var item in items11)
        // {
        // }
        //
        // IEnumerable<string> items12 = items11.AsEnumerable();
        // IQueryable<string> items13 = items11.AsQueryable();
        // var result1 = items12.Where(a => a == "mm");
        // var result2 = items13.Where(a => a == "mm").OrderBy(f=>f).ToList().Where(i=>i=="1212");

        var users = new List<User>()
        {
            new() { Name = "Ali", Age = 13 },
            new() { Name = "Vali", Age = 45 },
            new() { Name = "Ahmat", Age = 56 },
            new() { Name = "James", Age = 67 },
            new() { Name = "Jake", Age = 67 },
            new() { Name = "Esh", Age = 13 },
        };

        var filteredUsers = users.Where(u =>
        {
            //
            
            return u.Name.Contains("a") && u.Age > 50;
        }).ToArray();//5 minutes
        foreach (var user in filteredUsers)
        {
            Console.WriteLine(user);
        }

        var item1 = filteredUsers.FirstOrDefault(u=>u.Age == 23);

    }
}

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}