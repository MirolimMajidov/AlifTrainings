using NSubstitute;
using UsersService.Models;
using UsersService.NUnit.UnitTests.CommonData;

namespace UsersService.NUnit.UnitTests.Tests;

public class UserServiceTests : BaseTestEntity
{
    [Test]
    public void GetAll_ShouldReturnAllWorkers()
    {
        // Arrange
        var users = new List<User> { new User { FirstName = "John", LastName = "Doe" } }.AsQueryable();
        _repository.GetEntities().Returns(users);

        // Act
        var result = _userService.GetEntities();

        // Assert
        Assert.That(result, Is.EqualTo(users));
    }

    [Test]
    public void GetById_ShouldReturnWorker_WhenWorkerExists()
    {
        // Arrange
        var user = new User { FirstName = "John", LastName = "Doe" };
        _repository.GetById(user.Id).Returns(user);

        // Act
        var result = _userService.GetById(user.Id);

        // Assert
        Assert.That(result, Is.EqualTo(user));
    }

    // [Test]
    // public void TryCreate_ShouldReturnErrorMessage_WhenFirstNameOrLastNameIsEmpty()
    // {
        // // Arrange
        // var worker = new User { FirstName = "", LastName = "Doe" };
        // string message;
        //
        // // Act
        // var result = _userService.TryCreate(worker, out message);
        //
        // // Assert
        // Assert.That(result, Is.Null);
        // Assert.That(message, Is.EqualTo("The first name or last name is be empty"));
    // }

    // [Test]
    // public void TryCreate_ShouldCreateWorker_WhenFirstNameAndLastNameAreProvided()
    // {
    //     // Arrange
    //     var worker = new Worker { FirstName = "John", LastName = "Doe" };
    //     _repository.TryCreate(worker, out Arg.Any<string>()).Returns(worker);
    //
    //     // Act
    //     var result = _userService.TryCreate(worker, out string message);
    //
    //     // Assert
    //     Assert.That(result, Is.EqualTo(worker));
    //     Assert.That(message, Is.Null);
    // }
    //
    // [Test]
    // public void TryUpdate_ShouldReturnFalse_WhenWorkerNotFound()
    // {
    //     // Arrange
    //     var workerId = Guid.NewGuid();
    //     var worker = new Worker { FirstName = "John", LastName = "Doe" };
    //     _repository.GetById(workerId).Returns(Task.FromResult((Worker)null));
    //
    //     // Act
    //     var result = _userService.TryUpdate(workerId, worker, out string message);
    //
    //     // Assert
    //     Assert.That(result, Is.False);
    //     Assert.That(message, Is.EqualTo("Item not found"));
    // }
    //
    // [Test]
    // public void TryUpdate_ShouldUpdateWorker_WhenWorkerIsFound()
    // {
    //     // Arrange
    //     var existingWorker = new Worker { FirstName = "John", LastName = "Doe" };
    //     var updatedWorker = new Worker { FirstName = "Jane", LastName = "Smith" };
    //     _repository.GetById(existingWorker.Id).Returns(Task.FromResult(existingWorker));
    //     _repository.TryUpdate(existingWorker, out Arg.Any<string>()).Returns(true);
    //
    //     // Act
    //     var result = _userService.TryUpdate(existingWorker.Id, updatedWorker, out string message);
    //
    //     // Assert
    //     Assert.That(result, Is.True);
    //     Assert.That(message, Is.Null);
    //     Assert.That(existingWorker.FirstName, Is.EqualTo("Jane"));
    //     Assert.That(existingWorker.LastName, Is.EqualTo("Smith"));
    // }
    //
    // [Test]
    // public void TryDelete_ShouldDeleteWorker_WhenWorkerIsFound()
    // {
    //     // Arrange
    //     var workerId = Guid.NewGuid();
    //     _repository.TryDelete(workerId, out Arg.Any<string>()).Returns(true);
    //
    //     // Act
    //     var result = _userService.TryDelete(workerId, out string message);
    //
    //     // Assert
    //     Assert.That(result, Is.True);
    //     Assert.That(message, Is.Null);
    // }
}
