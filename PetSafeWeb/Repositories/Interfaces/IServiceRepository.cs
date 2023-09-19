using ClassLibrary1.Entities;
using PetSafeWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetSafeWeb.Repositories.Interfaces
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        List<Service> GetServicesList();

        string GetServiceIds(List<Service> services);

        Task<List<Service>> GetServicesFromString(string source);

        List<Service> MatchServicesList(string source);

        //List<Service> GetActiveServicesList(RoomViewModel model);

        //Task CreateRoomServices(Room room, List<Service> services);

        //Task<bool> RoomServiceExists(Room room, Service service);

        //Service GetServiceByName(string name);

        //Task<List<RoomServices>> GetActiveRoomServices(Room room);

    }
}
