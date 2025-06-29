using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Queue_Pro.API.Contracts;
using Queue_Pro.Application.Services;
using Queue_Pro.Domain.Abstractions;
using Queue_Pro.Domain.Models;
using LoginRequest = Queue_Pro.API.Contracts.LoginRequest;

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
    public async Task<ActionResult<Guid>> RegisterUser([FromBody] UsersRequest request)
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
    
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginRequest request)
    {
        var token = await _usersService.Login(request.Username, request.Password);
        return (token is not null) ? Ok(token) : BadRequest();
    }
    
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
    {
        return Ok((await _usersService.GetAllUsers())
            .Select(u => new UserResponse(u.Id, u.Username, u.FirstName, u.LastName, u.Surname)));
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<UserResponse?>> GetUserById(Guid id)
    {
        var user = await _usersService.GetUserById(id);
        if (user is null) return NotFound();
        
        return Ok(new UserResponse(user.Id, user.Username, user.FirstName, user.LastName, user.Surname));
    }


}