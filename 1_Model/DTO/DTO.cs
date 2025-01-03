using System.ComponentModel.DataAnnotations;

namespace Gym.API.DTO;

public class GymInputDTO
{
    public required string Name { get; set; }
    public required string StreetAddress { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required int Zipcode { get; set; }
}

public class GymOutputDTO
{

}


public class UserInputDTO
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public required string Email { get; set; }
    public required string Password { get; set; }
}
public class UserOutputDTO
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
