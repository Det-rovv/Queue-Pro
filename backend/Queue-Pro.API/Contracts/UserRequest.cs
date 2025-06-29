namespace Queue_Pro.API.Contracts;

public record UserRequest(
    string Username,
    string FirstName,
    string LastName,
    string? Surname,
    string Password);