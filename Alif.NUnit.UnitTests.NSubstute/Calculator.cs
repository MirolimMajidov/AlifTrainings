public interface ILogger
{
    public string Type { get; set; }
    void Log(string message);
    void Add(User user);

    public string GetType()
    {
        return Type;
    }
}

public class User()
{
    public int Age { get; set; }
}

public class Calculator
{
    private readonly ILogger _logger;
    public int maxNumber = 5;

    public Calculator(ILogger logger)
    {
        _logger = logger;
    }

    public int Add(int a, int b)
    {
        var user = new User(){Age = a };
        _logger.Add(user);
        _logger.Log($"Adding {a} and {b}");
        _logger.Log($"Adding {a} and {b}");
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        _logger.Log($"Subtracting {b} from {a}");
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        _logger.Log($"Multiplying {a} and {b}");
        return a * b;
    }

    public double Divide(int a, int b)
    {
        if (b == 0)
        {
            _logger.Log("Attempted to divide by zero");
            throw new ArgumentException("Cannot divide by zero.");
        }

        _logger.Log($"Dividing {a} by {b}");
        return (double)a / b;
    }
}