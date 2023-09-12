using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }

        public Client Client { get; set; }
        
        public int ClientId { get; set; }

        public Animal Animal { get; set; }

        public int AnimalId { get; set; }

        public Doctor Doctor { get; set; }

        public int DoctorId { get; set;}

        //insert time of appointment here somehow.
    }
}
