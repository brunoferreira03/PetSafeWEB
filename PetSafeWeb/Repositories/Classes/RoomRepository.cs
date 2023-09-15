using ClassLibrary1.Entities;
using PetSafeWeb.Data;
using PetSafeWeb.Repositories.Interfaces;

namespace PetSafeWeb.Repositories.Classes
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private readonly DataContext _context;

        public RoomRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
