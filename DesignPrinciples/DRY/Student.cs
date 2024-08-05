namespace DesignPrinciples.DRY;

public class Student:Person
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

    //KISS (Keep it simple, stupid!)
    public void DoJobAfterRegistration()
    {
        //Give bonus BL
        //Create Account BL
        //.....
        GiveBonus();
        //TODO
        CreateBankAccounts();
        //
    }

    public void GiveBonus()
    {
        
    }
    public void CreateBankAccounts()
    {
        
    }
}