using ClassLibrary1.Entities;
using PetSafeWeb.Data;
using PetSafeWeb.Repositories.Interfaces;

namespace PetSafeWeb.Repositories.Classes
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
