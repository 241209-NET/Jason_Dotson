using Gym.API.DTO;
using Gym.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Gym.API.Controller;

[Route("/")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) => _userService = userService;
  
    [HttpGet("/users")]
    public IActionResult GetAllUsers()
    {
        var userList = _userService.GetAllUsers();
        return Ok(userList);
    }

    [HttpGet("/users/{id}")]
    public IActionResult GetUserById(int id)
    {
        try
        {
            var foundUser = _userService.GetUserById(id);
            return Ok(foundUser);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("users/lastname/{lastname}")]
    public IActionResult GetUserByLastName(string lastname)
    {
        var userList = _userService.GetUserByLastName(lastname);
        return Ok(userList);
    }

    [HttpPost("/users")]
    public IActionResult CreateNewUser(UserInputDTO newUser)
    {
        var user = _userService.CreateNewUser(newUser);
        return Ok(user);
    }

    [HttpDelete("/users/{id}")]
    public IActionResult DeleteUserById(int id)
    {
        var deleteUser = _userService.DeleteUserById(id);

        if(deleteUser is null) return NotFound();

        return Ok(deleteUser);
    }

}