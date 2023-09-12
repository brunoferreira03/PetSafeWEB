using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class ClientAnimal : IEntity
    {
        public int Id { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }

        public Animal Animal { get; set; }

        public int AnimalId { get; set; }
    }
}
