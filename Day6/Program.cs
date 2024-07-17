using System.Net.NetworkInformation;
using System.Numerics;

Console.WriteLine("Hello, World!");
var student = new Student() { Age = 50 };
Worker worker = new() { Age = 60 };
// student.DoWork();
// worker.DoWork();
// new Teacher().DoWork();
//
// User studentUser = student;
// User workerUser = worker;
//
// Console.WriteLine(worker.Age);
// Console.WriteLine(workerUser.Age);

// Interface1 student1 = (Interface1)student;
// Interface2 student2 = student as Interface2;
// student.DoWork();
// student1.DoWork();
// student2.DoWork();

var cal = new Calculator<float>();
cal.Salary = 213.34f;
var value = cal.GetSum2(23);

Console.WriteLine("End");

public class Calculator<T> where T : INumber<T>
{
    public T Salary { get; set; }
    public T Tax { get; set; }

    public T GetSum()
    {
        return Salary + Tax;
    }
    
    public T2 GetSum2<T2>(T2 value)
    {
        return value;
    }
}

public abstract class User
{
    public User()
    {
    }

    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public User(int Age)
    {
        this.Age = Age;
    }

    public int Id { get; set; }

    private string _lastName;

    public string LastName
    {
        get { return _lastName; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidOperationException("Text");

            _lastName = value;
        }
    }

    public string FirstName { get; set; }
    public int Age { get; set; }

    public bool IsDeleted { get; set; }

    public string GetFullName() => $"{FirstName} {LastName}";

    public virtual void DoWork()
    {
        Console.WriteLine($"{this.GetType().Name} is working");
    }

    // public void PayTax(double amount)
    // {
    //     //TODO: Bad way
    // }
}

public class Student : User, Interface1, Interface2
{
    public int Course { get; set; }
    public string Speciality { get; set; }

    public new int Age { get; set; }

    void Interface1.DoWork()
    {
        Console.WriteLine($"{this.GetType().Name} is working from the interface1");
    }
}

public class Worker : User
{
    public double Salary { get; set; }
}

public class Teacher : User
{
    public string Level { get; set; }

    public void DoWork(string jobName)
    {
        Console.WriteLine(jobName);
    }

    public override void DoWork()
    {
        base.DoWork();
        DoWork("Finished the job");
        Console.WriteLine($"{this.GetType().Name} ready to work");
    }
}

public interface Interface1
{
    void DoWork();
}

public interface Interface2
{
    void DoWork();
}