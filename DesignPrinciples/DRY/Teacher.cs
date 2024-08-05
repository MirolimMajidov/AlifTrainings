namespace DesignPrinciples.DRY;

public class Teacher : Person
{
    // public void DoWork()
    // {
    //     
    // }

    public void SendEmail(string message)
    {
        var emailSender = new EmailSender();
        emailSender.SendEmail(message);
        
        
    }
}