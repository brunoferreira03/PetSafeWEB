using ClassLibrary1.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetSafeWeb.Models.Room_Models
{
    public class RoomViewModel : Room
    {
        [Display(Name = "Available Services")]
        public List<Service> Services;

        [Display(Name = "Services in Room")]
        public List<RoomServices> RoomServices;
    }
}
