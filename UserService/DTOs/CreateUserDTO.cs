using System.ComponentModel.DataAnnotations;

namespace UserService.DTOs;

public record CreateUserDTO
{
    [Required]
    public string FirstName { get; init; }
    
    [Required, Length(5, 30)]
    public string LastName { get; init; }
    
    public int Age { get; init; }
}