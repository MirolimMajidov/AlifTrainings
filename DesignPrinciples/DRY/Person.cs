namespace DesignPrinciples.DRY;

public abstract class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public void DoWork()
    {
        
    }

}