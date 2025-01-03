using Gym.API.Data;
using Gym.API.Repository;
using Gym.API.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("gym_membership")));

// Add dbcontext with connection string
builder.Services.AddDbContext<GymContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("gym_membership")));

// Add service dependencies
builder.Services.AddScoped<IGymService, GymService>();
builder.Services.AddScoped<IUserService, UserService>();

// Add repository dependencies 
builder.Services.AddScoped<IGymRepository, GymRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();



// Add controllers
builder.Services.AddControllers()
       .AddJsonOptions(options => 
       {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
       });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map Controllers
app.MapControllers();
app.Run();