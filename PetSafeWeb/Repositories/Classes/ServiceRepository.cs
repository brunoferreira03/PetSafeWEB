using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;
using PetSafeWeb.Data;
using PetSafeWeb.Models.Room_Models;
using PetSafeWeb.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetSafeWeb.Repositories.Classes
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly DataContext _context;

        public ServiceRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public List<Service> GetServicesList()
        {
            var list = new List<Service>();

            list = _context.Services.Select(s => new Service
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Price = s.Price,
            }).OrderBy(s => s.Name).ToList();

            return list;
        }

        public async Task CreateRoomServices(Room room, List<Service> services)
        {
            if (services == null)
                return;

            foreach (var service in services)
            {
                if (await RoomServiceExists(room, service))
                {
                    if (!service.IsActive)
                    {
                        var roomService = await _context.RoomServices.FirstOrDefaultAsync(rs => rs.RoomId == room.Id && rs.ServiceId == service.Id);

                        _context.RoomServices.Remove(roomService);
                    }
                }
                else
                {
                    if (service.IsActive)
                    {
                        var serviceToUse = GetServiceByName(service.Name);
                        serviceToUse.IsActive = true;
                        var roomService = new RoomServices
                        {
                            RoomId = room.Id,
                            Service = serviceToUse,
                        };
                        serviceToUse.IsActive = false;

                        await _context.RoomServices.AddAsync(roomService);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public Service GetServiceByName(string name)
        {
            var service = _context.Services.FirstOrDefault(s => s.Name == name);

            return service;
        }

        public async Task<bool> RoomServiceExists(Room room, Service service)
        {
            if (await _context.RoomServices.AnyAsync(rs => rs.RoomId == room.Id && rs.ServiceId == service.Id))
            {
                return true;
            }
            else return false;
        }

        public List<Service> GetActiveServicesList(RoomViewModel model)
        {
            var services = GetServicesList();
            var servicesToUse = new List<Service>();

            foreach (var service in services)
            {
                servicesToUse.Add(service);
            }

            for (int i = 0; i < model.RoomServices.Count; i++)
            {
                foreach (var service in servicesToUse)
                {
                    if (service.Id == model.RoomServices[i].ServiceId)
                    {
                        service.IsActive = true;
                    }
                }
            }

            return servicesToUse;
        }

        public async Task<List<RoomServices>> GetActiveRoomServices(Room room)
        {
            var services = _context.RoomServices.Where(r => r.RoomId == room.Id).ToList();

            foreach (var service in services)
            {
                service.Service = await GetByIdAsync(service.ServiceId);
            }

            return services;
        }
    }
}
