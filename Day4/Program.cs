using Day3Library;

namespace Day4;

class Program
{
    static void Main(string[] args)
    {
        var user = "James";
        //Calling methods
        //PrintHello(user);
        //PrintBye(user);

        //Example 1: Executing methods with the delegate
        //PrintMessage printer;
        //printer = PrintHello;
        //printer(user);
        //printer = PrintBye;
        //printer(user);

        //Example 2: Executing methods with the delegate
        // Conversation(user, PrintHello);
        // Conversation(user, PrintBye);

        //Example 3: Using action delegate
        // Action<string> actionPrinter;
        // actionPrinter = PrintHello;
        // actionPrinter(user);

        //Example 4: Using function delegate
        // Func<string, int, string> userInfoPrinter = UserInfoPrinter;
        // var userInfo = userInfoPrinter(user, 17);
        // Console.WriteLine(userInfo);

        //Example 5: Using action delegate as lambdas
        // Action<string> actionPrinter = (message) =>
        // {
        //     Console.WriteLine(message);
        // };
        // actionPrinter("Hello Jake");

        //Example 6: Using function delegate as lambdas
        // Func<string, int, string> functionPrinter = (userName, age) =>
        // {
        //     return $"User name is {userName} and age is {age}";
        // };
        // var userInfo = functionPrinter(user, 17);
        // Console.WriteLine(userInfo);

        //Example 7: Using an event with the default eventargs
        // Notification += (sender, eventArgs) =>
        // {
        //      Console.WriteLine("First notification is handeled");
        // };
        // Notification += (sender, eventArgs) =>
        // {
        //     var mysenderClass = sender as Program;
        //     Console.WriteLine("Second notification is handeled");
        // };

        //Notification.Invoke(null, EventArgs.Empty);

        //Example 8: Using an event with the custom eventargs
        var userService = new UserService(user);
        userService.SalaryPaid += (sender, eventArgs) =>
        {
            var userService = sender as UserService;
            if (userService is not null)
                Console.WriteLine($"{userService.Name}'s salary is paid");
        };
        userService.SalaryPaid += SendNotificationAfterPayingSalary;
        userService.PaySalary(999);
        //userService.SalaryPaid -= SendNotificationAfterPayingSalary; //Unsubscribing event to avoid of unmanage memory issue
    }

    public static event EventHandler Notification;

    static void SendNotificationAfterPayingSalary(object? sender, SalaryEventArgs eventArgs)
    {
        var userService = sender as UserService;
        Console.WriteLine(
            $"Notification is sent after paying {eventArgs.PaidSalary} amount as salary to {userService!.Name} user");
    }

    static string UserInfoPrinter(string userName, int age)
    {
        return $"User name is {userName} and age is {age}";
    }

    static void Conversation(string user, PrintMessage printer)
    {
        //Some logics
        printer(user);
        //Some logics
    }

    void HelloConversation(string user)
    {
        SomeLogics1();
        Console.WriteLine($"Hello {user}");
        SomeLogics2();
    }

    void ByeConversation(string user)
    {
        SomeLogics1();
        Console.WriteLine($"See you {user}");
        SomeLogics2();
    }

    void SomeLogics1()
    {
        //Some logics
    }

    void SomeLogics2()
    {
        //Some logics
    }

    static void PrintHello(string user)
    {
        Console.WriteLine($"Hello {user}");
    }

    static void PrintBye(string user)
    {
        Console.WriteLine($"See you {user}");
    }

    public delegate void PrintMessage(string text);
}