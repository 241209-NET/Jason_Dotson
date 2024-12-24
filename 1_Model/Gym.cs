using System.ComponentModel.DataAnnotations;

namespace Gym.API.Model;

public class Gym
{   
    [Key]
    public int GymId { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
}