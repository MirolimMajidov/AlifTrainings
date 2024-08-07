namespace UsersService.DTOs;

public record TokenInfoDto
{
    public string AccessToken { get; init; }

    public string RefreshToken { get; init; }

    public DateTimeOffset ExpireTime { get; init; }
}