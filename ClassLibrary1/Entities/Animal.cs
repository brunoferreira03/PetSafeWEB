using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class Animal : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int clientID { get; set; }
       
        public string TypeOfAnimal { get; set; }

        public string? RaceOfAnimal { get; set; }
    }
}
