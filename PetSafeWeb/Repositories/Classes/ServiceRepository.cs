using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;
using PetSafeWeb.Data;
using PetSafeWeb.Models;
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

        public string GetServiceIds(List<Service> Services)
        {
            string ids = string.Empty;

            foreach (var service in Services)
            {
                if (service.IsActive)
                ids += service.Id.ToString() + ",";
            }

            ids = ids.Substring(0, ids.Length - 1);

            return ids;
        }

        public async Task<List<Service>> GetServicesFromString(string source)
        {
            string[] ids = source.Split(',');
            List<Service> services = new List<Service>();

            foreach (var item in ids)
            {
                services.Add(await GetByIdAsync(int.Parse(item)));
            }

            return services;
        }

        public List<Service> MatchServicesList(string source)
        {
            var services = GetServicesList();
            string[] ids = source.Split(',');

            if (ids.Length <= 0) return services;

            foreach (var item in ids)
            {
                foreach (var service in services)
                {
                    if (int.Parse(item) == service.Id)
                        service.IsActive = true;
                }
            }

            return services;
        }
    }
}
