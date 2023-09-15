using ClassLibrary1.Entities;
using PetSafeWeb.Data;
using PetSafeWeb.Repositories.Interfaces;

namespace PetSafeWeb.Repositories.Classes
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly DataContext _context;

        public DoctorRepository(DataContext context) : base(context)
        {
                _context = context;
        }
    }
}
