namespace DesignPrinciples.SOLID;

public abstract class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    //public int Course { get; set; }  BAD
}