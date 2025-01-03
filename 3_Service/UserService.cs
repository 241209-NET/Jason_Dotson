using Gym.API.DTO;
using Gym.API.Model;
using Gym.API.Repository;

namespace Gym.API.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository) => _userRepository = userRepository;

    public Model.User CreateNewUser(UserInputDTO newUser)
    {
        Model.User fromDTO = new Model.User{
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            Email = newUser.Email,
            Password = newUser.Password,
            UserAuthorityId = 3
        };
        var user = _userRepository.CreateNewUser(fromDTO);
        return user;
    }

    public Model.User DeleteUserById(int id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            throw new ArgumentException($"User with ID {id} does not exist.");
        }

        return _userRepository.DeleteUserById(user);
    }

    public IEnumerable<Model.User> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        if (!users.Any())
        {
            return [];
        }
        foreach (var user in users)
        {
            user.Password = "********";
        }
        return users;
    }

    public Model.User? GetUserById(int id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            throw new ArgumentException($"User with ID {id} does not exist.");
        }
        user.Password = "********";
        return user;
    }

    public IEnumerable<Model.User> GetUserByLastName(string lastName)
    {
        if(String.IsNullOrEmpty(lastName)) return [];
        
        var userList = _userRepository.GetUserByLastName(lastName);
        foreach (var user in userList)
        {
            user.Password = "********";
        }
        return userList;
    }

    public User UpdateUser(int id, User _user)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            throw new ArgumentException($"User with ID {id} does not exist.");
        }

        return _userRepository.UpdateUser(id, _user)!;
    }
}