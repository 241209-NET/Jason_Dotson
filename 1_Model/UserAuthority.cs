using System.ComponentModel.DataAnnotations;

namespace Gym.API.Model;

public class UserAuthority
{
    [Key]
    public int UserAuthorityId { get; set; }
    public required string Authority { get; set; }

}