using System.IO.Compression;
using System.Text;

namespace Day9;

class Program
{
    static void Main(string[] args)
    {
        // var age1 = 20;
        // age1 = 22;
        // var age2 = age1;
        // age2 += 2;
        // UpdateAge(ref age1);
        // Console.WriteLine($"Age 1: {age1} ");
        // Console.WriteLine($"Age 2: {age2} ");
        //
        // var user1 = new User { Age = 20 };
        // var user2 = user1;
        // user2.Age += 2;
        // UpdateAge(user1);
        // Console.WriteLine($"User age 1: {user1.Age} ");
        // Console.WriteLine($"User age 2: {user2.Age} ");
        //
        // var name1 = "Ali";
        // var name2 = name1;
        // name2 = "Vali";
        // Console.WriteLine($"Name 1: {name1} ");
        // Console.WriteLine($"Name 2: {name2} ");

        // string[] items = ["Valiev", "Ali", "Rahmonovich"];
        // var fio = string.Empty;
        // var fio1 = new StringBuilder();
        // foreach (var name in items)
        // {
        //     fio += $" {name}";
        //     //fio1.Append(Environment.s);
        //     fio1.Append(name);
        //     Console.WriteLine($"Factorial: {fio}");
        // }
        //
        // Console.WriteLine($"FIO : {fio}");
        // Console.WriteLine($"FIO : {fio1.ToString()}");

        // using (var user = new User())
        // {
        //     user.Age = 34;
        // }
        
        // using var user = new User();
        // user.Age = 34;
        
        var user = new User();
        user.Age = 34;
        user.Dispose();
        
        if(user is IDisposable disposable)
            disposable.Dispose();
    }

    static void UpdateAge(ref int age)
    {
        age += 5;
    }

    static void UpdateAge(User user)
    {
        user.DoWork();
        user.Age += 5;
    }
}

class User : IDisposable
{
    public event EventHandler Test ;
    public int Age { get; set; }

    public void DoWork()
    {
        
    }

    public void Dispose()
    {
        //TODO: Test unsubscribe all subscribed resources
        Console.WriteLine("User removed");
        // TODO release managed resources here
    }

    ~User()
    {
        Dispose();
    }
}