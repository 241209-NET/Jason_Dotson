using System.ComponentModel.DataAnnotations;


namespace Gym.API.Model;

public class User 
{
    [Key]
    public int UserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required int UserAuthorityId { get; set; }
    public int GymId { get; set; }
}