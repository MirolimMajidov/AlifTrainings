namespace Alif.NUnit.UnitTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        //Run before each tests
    }

    [Test]
    public void Test1_UseCase_Expectation()
    {
        var a = 2;
        var b = 6;
        //Assert.That(a+b, Is.EqualTo(11));
        Assert.AreEqual(a+b, 8, "My message");
    }

    [Test]
    public void Test2()
    {
        var a = 5;
        var b = 6;
        Assert.That(a+b, Is.EqualTo(11));
    }
    
    [TearDown]
    public void TearDown()
    {
        //Run after each tests
    }
}