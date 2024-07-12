namespace Day3Library;

public class UserService
{
    public string Name { get; set; }
    public event EventHandler<SalaryEventArgs> SalaryPaid;

    public UserService(string name)
    {
        Name = name;
    }

    public void PaySalary(double salary)
    {
        SalaryPaid.Invoke(this, new SalaryEventArgs(salary));
    }
}

public class SalaryEventArgs : EventArgs
{
    public double PaidSalary { get; set; }

    public SalaryEventArgs(double paidSalary)
    {
        PaidSalary = paidSalary;
    }
}