using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Day7Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Started!");
        var watch = Stopwatch.StartNew();

        //Example with Thread
        // var thread1 = new Thread(MessagePrinter);
        // thread1.Start("Hello message 1");
        // var thread2 = new Thread(MessagePrinter);
        // thread2.Start("Hello message 2");

        //Example with Task
        // var task1 = Task.Run(() => MessagePrinterWithTime("Hello message 1", 3));
        // var task2 = Task.Run(() => MessagePrinterWithTime("Hello message 2", 2));
        // var task3 = new Task(() => MessagePrinterWithTime("Hello message 3", 2));
        // task2.ContinueWith((t) =>
        // {
        //     Console.WriteLine("Task2 Finished");
        //     task3.Start();
        // });
        //
        // Task[] tasks = [task1, task2, task3];
        // Task.WaitAll(tasks);

        // using var timeoutCancellationTokenSource = new CancellationTokenSource();
        // timeoutCancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(2));
        // var cancellationToken = timeoutCancellationTokenSource.Token;
        // var task1 = Task.Run(() => MyLoop(cancellationToken));
        // task1.Wait();
        
        
        
        watch.Stop();

        Console.WriteLine($"Finished! spent time: {watch.ToString()}");
    }
    static void MyLoop(CancellationToken cancellationToken = default)
    {
        for (int i = 0;;)
        {
            Thread.Sleep(100);
            if(cancellationToken.IsCancellationRequested)
                return;
            
            i++;
            Console.WriteLine($"Item: {i}");
        }
    }

    static void MessagePrinter(string message)
    {
        Thread.Sleep(2000);
        Console.WriteLine(message);
    }


    static void MessagePrinterWithTime(string message, int seconds = 2)
    {
        Thread.Sleep(TimeSpan.FromSeconds(seconds));
        Console.WriteLine(message);
    }
}