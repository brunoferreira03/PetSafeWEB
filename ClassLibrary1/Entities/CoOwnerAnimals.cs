using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class CoOwnerAnimals
    {
        public Client Owner { get; set; }

        public int OwnerId { get; set; }

        public Client CoOwner { get; set; }

        public int CoOwnerId { get; set; }
        
        public Animal Pet { get; set; }

        public int PetId { get; set;}
    }
}
