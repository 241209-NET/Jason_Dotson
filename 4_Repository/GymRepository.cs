namespace Gym.API.Repository;
using Gym.API.Data;
public class GymRepository : IGymRepository
{
    private readonly GymContext _gymContext;
    public GymRepository(GymContext gymContext) => _gymContext = gymContext;
    // Repository CRUD operations
    public Model.Gym CreateNewGym(Model.Gym newGym)
    {
        _gymContext.Gyms.Add(newGym);
        _gymContext.SaveChanges();
        return newGym;
    }

    public Model.Gym DeleteGymById(Model.Gym deleteGym)
    {
        _gymContext.Gyms.Remove(deleteGym);
        _gymContext.SaveChanges();
        return deleteGym;
    }

    public IEnumerable<Model.Gym> GetAllGyms()
    {
        return _gymContext.Gyms.ToList();
    }

    public Model.Gym? GetGymById(int id)
    {
        return _gymContext.Gyms.Find(id);
    }

    public IEnumerable<Model.Gym> GetGymByName(string name)
    {
       var gymList = _gymContext.Gyms.Where(p => p.Name.Contains(name)).ToList();
       return gymList;
    }
}