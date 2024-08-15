using NSubstitute;
using UsersService.Models;
using UsersService.Repositories;
using UsersService.Services;

namespace UsersService.NUnit.UnitTests.CommonData
{
    public abstract class BaseTestEntity
    {
        protected IUserService _userService;
        protected ICRUDRepository<User> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<ICRUDRepository<User>>();
            _userService = new UserService(_repository);
        }
    }
}