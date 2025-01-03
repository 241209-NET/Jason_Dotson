namespace Gym.API.Repository;

using System.Collections.Generic;
using Gym.API.Data;
using Gym.API.Model;

public class UserRepository : IUserRepository
{
    private readonly GymContext _gymContext;
    public UserRepository(GymContext gymContext) => _gymContext = gymContext;

    public User CreateNewUser(User newUser)
    {
        _gymContext.Users.Add(newUser);
        _gymContext.SaveChanges();
        return newUser;
    }

    public User DeleteUserById(User deleteUser)
    {
        _gymContext.Users.Remove(deleteUser);
        _gymContext.SaveChanges();
        return deleteUser;
    }

    public IEnumerable<User> GetAllUsers()
    {
       return _gymContext.Users.ToList();
    }

    public User? GetUserById(int id)
    {
         return _gymContext.Users.Find(id);
    }

    public IEnumerable<User> GetUserByLastName(string lastName)
    {
       var userList = _gymContext.Users.Where(p => p.LastName.Contains(lastName)).ToList();
       return userList;
    }
    public User UpdateUser(int id, User _user)
    {
        var user = GetUserById(id)!;
        user.FirstName = _user.FirstName;
        user.LastName = _user.LastName;
        user.Email = _user.Email;
        user.Password = _user.Password;
        _gymContext.SaveChanges();
        return _user;
    }
}