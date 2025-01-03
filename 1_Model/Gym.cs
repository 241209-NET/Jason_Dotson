using System.ComponentModel.DataAnnotations;
namespace Gym.API.Model;
public class Gym
{   
    [Key]
    public int GymId { get; set; }
    public required string Name { get; set; }
    public required string StreetAddress { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required int Zipcode { get; set; }
}