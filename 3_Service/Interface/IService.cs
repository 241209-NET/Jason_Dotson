namespace Gym.API.Service;

using Gym.API.DTO;
using Gym.API.Model;

public interface IGymService 
{
    Gym CreateNewGym(GymInputDTO newGym);
    IEnumerable<Gym> GetAllGyms();
    IEnumerable<Gym> GetGymByName(string name);
    Gym? GetGymById(int id);
    Gym DeleteGymById(int id);
}

public interface IUserService
{
    User CreateNewUser(UserInputDTO newUser);
    IEnumerable<User> GetAllUsers();
    IEnumerable<User> GetUserByLastName(string lastName);
    User? GetUserById(int id);
    User UpdateUser(int id, User _user);
    User DeleteUserById(int id);
}
