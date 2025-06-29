namespace Queue_Pro.API.Contracts;

public record UsersRequest(
    string Username,
    string FirstName,
    string LastName,
    string? Surname,
    string Password);