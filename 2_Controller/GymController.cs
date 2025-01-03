using Gym.API.DTO;
using Gym.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Gym.API.Controller;

[Route("/")]
[ApiController]
public class GymController : ControllerBase
{
    private readonly IGymService _gymService;

    public GymController(IGymService gymService) => _gymService = gymService;

    [HttpGet]
    public IActionResult ReturnHello()
    {
        return Ok("Hello.");
    }

    [HttpGet("/gyms")]
    public IActionResult GetAllGyms()
    {
        var gymList = _gymService.GetAllGyms();
        return Ok(gymList);
    }

    [HttpGet("/gyms/{id}")]
    public IActionResult GetGymById(int id)
    {
        try
        {
            var foundGym = _gymService.GetGymById(id);
            return Ok(foundGym);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("gyms/name/{name}")]
    public IActionResult GetGymByName(string name)
    {
        var gymList = _gymService.GetGymByName(name);
        return Ok(gymList);
    }

    [HttpPost("/gyms")]
    public IActionResult CreateNewGym(GymInputDTO newGym)
    {
        var gym = _gymService.CreateNewGym(newGym);
        return Ok(gym);
    }

    [HttpDelete("/gyms/{id}")]
    public IActionResult DeleteGymById(int id)
    {
        var deleteGym = _gymService.DeleteGymById(id);

        if(deleteGym is null) return NotFound();

        return Ok(deleteGym);
    }

}