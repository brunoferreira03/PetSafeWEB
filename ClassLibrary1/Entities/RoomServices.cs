using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities
{
    public class RoomServices : IEntity
    {
        public int Id { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }

        public Service Service { get; set; }

        public int ServiceId { get; set; }
    }
}
