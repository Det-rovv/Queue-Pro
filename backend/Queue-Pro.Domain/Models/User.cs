using Queue_Pro.Domain.Abstractions;

namespace Queue_Pro.Domain.Models;

public class User
{
    // public User(Guid id, string firstName, string lastName, string passwordHash, int order, string? surname)
    // {
    //     Id = id;
    //     FirstName = firstName;
    //     LastName = lastName;
    //     Surname = surname;
    //     PasswordHash = passwordHash;
    // }

    public Guid Id { get; set; }
    
    public string Username { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string? Surname { get; set; }
    
    public string Password { get; set; }
}