
using Microsoft.EntityFrameworkCore;

namespace Gym.API.Data;

// Name of project
public class GymContext : DbContext
{
    public GymContext(){}
    public GymContext(DbContextOptions<GymContext> options) : base(options){}

    public DbSet<API.Model.Gym> Gyms { get; set; }

}