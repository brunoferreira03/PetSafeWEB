using ClassLibrary1.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace PetSafeWeb.Data
{
    public class DataContext : IdentityDbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<ClientAnimal> ClientsAnimals { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Room> Rooms { get; set; }
        
        public DbSet<Appointment> Appointments { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}