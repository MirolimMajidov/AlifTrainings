namespace DesignPrinciples.SOLID;

public class Eagle: IAnimal, ICanFly
{
    public void CanFly()
    {
        throw new NotImplementedException();
    }

    public void CanRun()
    {
        //Bad
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