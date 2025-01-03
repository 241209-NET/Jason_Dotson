using Moq;
using Gym.API.DTO;
using Gym.API.Model;
using Gym.API.Repository;
using Gym.API.Service;


namespace Gym.TEST;

public class ServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository = new();
    private readonly Mock<IGymRepository> _mockGymRepository = new();
    private readonly UserService _userService;
    private readonly GymService _gymService;

    public ServiceTests()
    {
        _userService = new UserService(_mockUserRepository.Object);
        _gymService = new GymService(_mockGymRepository.Object);
    }

    [Fact]
    public void CreateActiveMemberSuccessTest()
    {
        // Arrange
        var newUserDTO = new UserInputDTO { FirstName = "Bobby-O", LastName = "Bob",
                                            Email = "bobby-bob@bobonetics.bob", Password = "Apple" };
        var newUser = new User
        {
            FirstName = "Bobby-O",
            LastName = "Bob",
            Email = "bobby-bob@bobonetics.bob",
            Password = "Apple",
            UserAuthorityId = 3
            
        };

        _mockUserRepository.Setup(repo => repo.CreateNewUser(It.IsAny<User>())).Returns(newUser);

        // Act
        var result = _userService.CreateNewUser(newUserDTO);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(newUser.FirstName, result.FirstName);
        Assert.Equal(newUser.LastName, result.LastName);
        Assert.Equal(newUser.Email, result.Email);
        Assert.Equal(newUser.Password, result.Password);
        _mockUserRepository.Verify(repo => repo.CreateNewUser(It.IsAny<User>()), Times.Once);
    }



    [Fact]
    public void GetUserByIdTest()
    {
        // Arrange
        var user = new User
        {
            UserId = 1,
            FirstName = "Bobby-O",
            LastName = "Bob",
            Email = "bobby-bob@bobonetics.bob",
            Password = "Apple",
            UserAuthorityId = 3
        };

        _mockUserRepository.Setup(repo => repo.GetUserById(1)).Returns(user);

        // Act
        var result = _userService.GetUserById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(user.UserId, result.UserId);
        _mockUserRepository.Verify(repo => repo.GetUserById(1), Times.Once);
    }

    [Fact]
    public void GetAllUsersTest()
    {
        // Arrange
        var users = new List<User>
        {
            new User
            {
                UserId = 1,
                FirstName = "Bobby-O",
                LastName = "Bob",
                Email = "bobby-bob@bobonetics.bob",
                Password = "Apple",
                UserAuthorityId = 3
            },
            new User
            {
                UserId = 2,
                FirstName = "Jelly",
                LastName = "Joe",
                Email = "Jelly-joe@joemama.com",
                Password = "jellyrolls",
                UserAuthorityId = 3
            },
            new User
            {
                UserId = 3,
                FirstName = "Bruce",
                LastName = "Wayne",
                Email = "batmobile@batcave.com",
                Password = "notBatman1",
                UserAuthorityId = 3
            },
        };

        _mockUserRepository.Setup(repo => repo.GetAllUsers()).Returns(users);

        // Act
        var result = _userService.GetAllUsers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(users.Count, result.Count());
        _mockUserRepository.Verify(repo => repo.GetAllUsers(), Times.Once);
    }

    [Fact]
    public void GetAllGymsTest()
    {
        // Arrange
        var gyms = new List<Gym.API.Model.Gym>
        {
            new Gym.API.Model.Gym
            {
                GymId = 1,
                Name = "Super Wacky Fitness",
                StreetAddress = "111 WackyOneBoulevard",
                City = "Arlington",
                State = "Texas",
                Country = "United States",
                Zipcode = 38119
            },
            new Gym.API.Model.Gym
            {
                GymId = 2,
                Name = "Purple Gym",
                StreetAddress = "199 Winfield Drive",
                City = "New York",
                State = "New York",
                Country = "United States",
                Zipcode = 41182
            }

        };

        _mockGymRepository.Setup(repo => repo.GetAllGyms()).Returns(gyms);

        // Act
        var result = _gymService.GetAllGyms();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(gyms.Count, result.Count());
        _mockGymRepository.Verify(repo => repo.GetAllGyms(), Times.Once);
    }

       [Fact]
    public void GetGymByIdTest()
    {
        // Arrange
        var gym = new Gym.API.Model.Gym
        {
            GymId = 1,
            Name = "Super Wacky Fitness",
            StreetAddress = "111 WackyOneBoulevard",
            City = "Arlington",
            State = "Texas",
            Country = "United States",
            Zipcode = 38119
        };

        _mockGymRepository.Setup(repo => repo.GetGymById(1)).Returns(gym);

        // Act
        var result = _gymService.GetGymById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(gym.GymId, result.GymId);
        _mockGymRepository.Verify(repo => repo.GetGymById(1), Times.Once);
    }

}