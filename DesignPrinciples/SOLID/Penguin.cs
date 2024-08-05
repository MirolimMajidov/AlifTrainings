namespace DesignPrinciples.SOLID;

public class Penguin : IAnimal
{
    public void CanFly()
    {
        //Cannot
        throw new NotImplementedException();
    }

    public void CanRun()
    {
        //Cannot
        throw new NotImplementedException();
    }

    public void CanWalk()
    {
        throw new NotImplementedException();
    }

    public void CanEat()
    {
        throw new NotImplementedException();
    }
}