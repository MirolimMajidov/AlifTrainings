namespace DesignPrinciples.SOLID;

public static class UserOCPExtensions
{
    //Open/Closed Principle
    public static void DoHobby(this UserSRP user, string name)
    {
    }

    //Liskov Substitution Principle
    public static void SendMessage( /*Person*/ StudentOCP person, string message)
    {
        var user = new UserSRP();
        var _message = $"{person.Name} send '{message}' message";

        //var logger = new LogToFile();
        var logger = new LogToDB();
        user.AddLog(logger, _message);
        Console.WriteLine(_message);
    }
}