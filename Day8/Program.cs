using System.Diagnostics;
using System.Formats.Tar;

namespace Day8;

class Program
{
    static async Task Main(string[] args)
    {
        var watch = Stopwatch.StartNew();
        // await TextPrinter("Message 1", 3); 
        // var task1 = TextPrinter("Message 1", 3); 
        // var task2 =  TextPrinter("Message 2", 2);
        //
        // Task.WaitAll(task1, task2);

        // var task1 = Hello(1, "Akbar", 3);
        // var task2 = Hello(2, "Murod", 2);
        // // var badWay = task1.Result;
        // // var goodWay = await task1;
        // var value2 = task1.GetAwaiter().GetResult();
        // Task.WaitAll(task2, task1);
        //var value22 = task1.Result;

        var task1 = SharedContext(1, "Akbar", 2);
        var task2 = SharedContext(2, "Akbar", 2);
        Task.WaitAll(task2, task1);
        // new List<int>() { 1, 3, 5, 8 }.ForEach(Square);
        //Parallel.For(1, 5, Square);

        // ParallelLoopResult result = Parallel.ForEach<int>(
        //     new List<int>() { 1, 3, 5, 8 },
        //     Square
        // );
        watch.Stop();
        Console.WriteLine($"Completed, time {watch.ToString()}!");
    }

    static void Square(int n)
    {
        Console.WriteLine($"Completed task: {Task.CurrentId}");
        Console.WriteLine($"Result of {n} is {n * n}");
        Thread.Sleep(TimeSpan.FromSeconds(0.5));
    }

    static async Task TextPrinter(string message, int seconds)
    {
        await Task.Run(() =>
        {
            Console.WriteLine($"Started {message} ");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine($"Finished {message} ");
        });
    }

    static async Task<string> SharedContext(int methodId, string name, int seconds)
    {
        for (int i = 0; i < 1000; i++)
        {
            Thread.Sleep(1);
            Console.WriteLine($"MessageId: {methodId}, item: {i}");
        }

        return await Hello(methodId, name, seconds);
    }

    static async Task<string> Hello(int methodId, string name, int seconds)
    {
        return await Task.Run(() =>
        {
            Console.WriteLine($"Started method {methodId} ");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine($"Finished method {methodId} ");

            return $"Hello {name}";
        });
    }
}

public class User
{
    public string Name {
        get;
        set;
    }

    public int Balance { get; set; } = 100;

    private object lockBalance = new object();
    public void TransferMoney(int amount)
    {
        lock (lockBalance)
        {
            if (Balance > amount)
            {
                Balance -= amount;
            }
        }

        // var mutex = new Mutex("test");
        // mutex.WaitOne();
        //
        //
        // mutex.ReleaseMutex();
        //
        // SemaphoreSlim slim = new SemaphoreSlim(19);
    }
}