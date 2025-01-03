namespace Gym.API.Repository;
using Gym.API.Model;

public interface IGymRepository
{
    Gym CreateNewGym(Gym newGym);
    IEnumerable<Gym> GetAllGyms();
    IEnumerable<Gym> GetGymByName(string name);
    Gym? GetGymById(int id);
    Gym DeleteGymById(Gym deleteGym);
}

public interface IUserRepository
{
    User CreateNewUser(User newUser);
    IEnumerable<User> GetAllUsers();
    IEnumerable<User> GetUserByLastName(string lastName);
    User? GetUserById(int id);
    User UpdateUser(int id, User _user);
    User DeleteUserById(User deleteUser);
}
