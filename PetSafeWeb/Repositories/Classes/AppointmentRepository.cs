using ClassLibrary1.Entities;
using PetSafeWeb.Data;
using PetSafeWeb.Repositories.Interfaces;

namespace PetSafeWeb.Repositories.Classes
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly DataContext _context;

        public AppointmentRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
