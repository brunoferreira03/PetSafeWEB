using ClassLibrary1.Entities;
using PetSafeWeb.Data;
using PetSafeWeb.Repositories.Interfaces;

namespace PetSafeWeb.Repositories.Classes
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        private readonly DataContext _context;

        public AnimalRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
