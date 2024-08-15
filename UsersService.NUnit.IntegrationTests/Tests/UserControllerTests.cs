using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using NUnit.Framework;
using UsersService.Models;
using UsersService.NUnit.IntegrationTests.CommonData;

namespace UsersService.NUnit.IntegrationTests.Tests
{
    internal class UserControllerTests : BaseTestEntity
    {
        [Test]
        public async Task GetAll_ShouldReturnAllUsers()
        {
            // Arrange
            var _client = Server.CreateClient();

            // Act
            var response = await _client.GetAsync("user");

            // Assert
            response.EnsureSuccessStatusCode();
            var users = await response.Content.ReadFromJsonAsync<IEnumerable<User>>();
            Assert.That(users.Any(), Is.True);
        }
        
        [Test]
        public async Task GetItemById_ShouldNotReturnUserByInvalidId()
        {
            // Arrange
            var id = Guid.NewGuid();
            var _client = Server.CreateClient();
        
            // Act
            var response = await _client.GetAsync($"User/{id}");
        
            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.False);
        }
        
        private async Task<Guid> GetFirstUserId()
        {
            var _client = Server.CreateClient();
            var response = await _client.GetAsync("/User");
            response.EnsureSuccessStatusCode();
            var users = await response.Content.ReadFromJsonAsync<IEnumerable<User>>();
            return users.First().Id;
        }
        
        [Test]
        public async Task GetItemById_ShouldReturnUserById()
        {
            // Arrange
            var id = await GetFirstUserId();
            var _client = Server.CreateClient();
        
            // Act
            var response = await _client.GetAsync($"User/{id}");
        
            // Assert
            response.EnsureSuccessStatusCode();
            var user = await response.Content.ReadFromJsonAsync<User>();
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Id, Is.EqualTo(id));
        }
        
        [Test]
        public async Task Post_ShouldNotCreateNewUser()
        {
            // Arrange
            var newUser = new User { };
            var content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
        
            // Act
            var response = await ExecuteRequest("User", content);
        
            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.False);
        }

        async Task<HttpResponseMessage> ExecuteRequest(string url, StringContent content)
        {
            var _client = Server.CreateClient();
            var response = await _client.PostAsync(url, content);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var token = string.Empty;
                
                return await ExecuteRequest(url, content);
            }

            return response;
        }
        
        [Test]
        public async Task Post_ShouldCreateNewUser()
        {
            // Arrange
            var _client = Server.CreateClient();
            var newUser = new User
            {
                FirstName = "Test",
                LastName = "User",
                Age = 35
            };
        
            // Act
            var response = await _client.PostAsJsonAsync("/User", newUser);
        
            // Assert
            response.EnsureSuccessStatusCode();
            var createdUser = await response.Content.ReadFromJsonAsync<User>();
            Assert.That(createdUser, Is.Not.Null);
            Assert.That(newUser.FirstName, Is.EqualTo(createdUser.FirstName));
        }
        
        // [Test]
        // public async Task Put_ShouldNotUpdateByInvalidId()
        // {
        //     // Arrange
        //     var _client = Server.CreateClient();
        //     var userId = Guid.NewGuid();
        //     var updateUser = new User
        //     {
        //         FirstName = "Updated",
        //         LastName = "User",
        //         Age = 40
        //     };
        //
        //     // Act
        //     var response = await _client.PutAsJsonAsync($"/User/Update?id={userId}", updateUser);
        //
        //     // Assert
        //     Assert.That(response.IsSuccessStatusCode, Is.False);
        // }
        //
        // [Test]
        // public async Task Put_ShouldUpdateByValidId()
        // {
        //     // Arrange
        //     var _client = Server.CreateClient();
        //     var userId = await GetFirstUserId();
        //     var updateUser = new User
        //     {
        //         FirstName = "Updated",
        //         LastName = "User",
        //         Age = 40
        //     };
        //
        //     // Act
        //     var response = await _client.PutAsJsonAsync($"/User/Update?id={userId}", updateUser);
        //
        //     // Assert
        //     response.EnsureSuccessStatusCode();
        //     var message = await response.Content.ReadAsStringAsync();
        //     Assert.That("Successfully updated", Is.EqualTo(message));
        // }
        //
        // [Test]
        // public async Task Delete_ShouldNotDeleteUserByInvalidId()
        // {
        //     // Arrange
        //     var _client = Server.CreateClient();
        //     var userId = Guid.NewGuid();
        //
        //     // Act
        //     var response = await _client.DeleteAsync($"/User/Delete?id={userId}");
        //
        //     // Assert
        //     Assert.That(response.IsSuccessStatusCode, Is.False);
        // }
        //
        // [Test]
        // public async Task Delete_ShouldDeleteUserByValidId()
        // {
        //     // Arrange
        //     var _client = Server.CreateClient();
        //     var userId = await GetFirstUserId();
        //
        //     // Act
        //     var response = await _client.DeleteAsync($"/User/Delete?id={userId}");
        //
        //     // Assert
        //     response.EnsureSuccessStatusCode();
        //     var message = await response.Content.ReadAsStringAsync();
        //     Assert.That("Successfully deleted", Is.EqualTo(message));
        // }
    }
}
