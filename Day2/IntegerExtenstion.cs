namespace Day2;

public static class IntegerExtenstion
{
    public static int Add(this int item1, int item2)
    {
        return item1 + item2;
    }
    
    public static int Multiply(this int item1, int item2)
    {
        return item1 * item2;
    }
    
    public static int CalculateSalary(this Worker worker, int days)
    {
        return 100 * days;
    }
}