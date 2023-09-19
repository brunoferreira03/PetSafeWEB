using ClassLibrary1.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetSafeWeb.Models
{
    public class RoomViewModel : Room
    {
        [Display(Name = "Available Services")]
        public List<Service> Services { get; set; }

        [Display(Name = "Services in Room")]
        public List<RoomServices> RoomServices { get; set; }
    }
}
