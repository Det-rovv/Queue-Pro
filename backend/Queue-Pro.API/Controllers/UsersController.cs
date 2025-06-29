using Microsoft.AspNetCore.Mvc;
using Queue_Pro.API.Contracts;
using Queue_Pro.Domain.Abstractions;
using Queue_Pro.Domain.Models;

namespace Queue_Pro.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] UsersRequest request)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Password = request.Password,
            Surname = request.Surname,
        };
        
        return Ok(await _usersService.RegisterUser(user));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await _usersService.GetAllUsers());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _usersService.GetUserById(id);
        if (user is null) return NotFound();
        return Ok(user);
    }
}