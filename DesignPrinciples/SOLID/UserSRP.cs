namespace DesignPrinciples.SOLID;

//Single Reponsitibily Principle
public class UserSRP
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CityName { get; set; }//Bad
    public int Age { get; set; }
    public string NameOfBrother { get; set; }//Bad
    
    //....

    // public void DoHobby(string name)
    // {
    //     
    // }
    
    //Dependency Inversion Principle
    //public void AddLog(LogToFile logger)
    public void AddLog(ILogger logger, string message)
    {
        logger.Log(message);
    }
}