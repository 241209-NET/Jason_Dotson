using Gym.API.DTO;
using Gym.API.Repository;


namespace Gym.API.Service;

public class GymService : IGymService
{
    private readonly IGymRepository _gymRepository;
    public GymService(IGymRepository gymRepository) => _gymRepository = gymRepository;

    public Model.Gym CreateNewGym(GymInputDTO newGym)
    {
        Model.Gym fromDTO = new Model.Gym{
            Name = newGym.Name,
            StreetAddress = newGym.StreetAddress,
            City = newGym.City,
            State = newGym.State,
            Country = newGym.Country,
            Zipcode = newGym.Zipcode
        };
        var gym = _gymRepository.CreateNewGym(fromDTO);
        return gym;
    }

    public Model.Gym DeleteGymById(int id)
    {
        var gym = _gymRepository.GetGymById(id);
        if (gym == null)
        {
            throw new ArgumentException($"Gym with ID {id} does not exist.");
        }

        return _gymRepository.DeleteGymById(gym);
    }

    public IEnumerable<Model.Gym> GetAllGyms()
    {
        var gyms = _gymRepository.GetAllGyms();
        if (!gyms.Any())
        {
            return [];
        }

        return gyms;
    }

    public Model.Gym? GetGymById(int id)
    {
        var gym = _gymRepository.GetGymById(id);
        if (gym == null)
        {
            throw new ArgumentException($"Gym with ID {id} does not exist.");
        }

        return gym;
    }

    public IEnumerable<Model.Gym> GetGymByName(string name)
    {
        if(String.IsNullOrEmpty(name)) return [];
        
        var gymList = _gymRepository.GetGymByName(name);
        return gymList;
    }
}