namespace Queue_Pro.API.Contracts;

public record UserResponse(
    Guid Id,
    string Username,
    string FirstName,
    string LastName,
    string? Surename);