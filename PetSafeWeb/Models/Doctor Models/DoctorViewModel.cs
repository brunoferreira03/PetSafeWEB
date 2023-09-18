using ClassLibrary1.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PetSafeWeb.Models.DoctorModels
{
    public class DoctorViewModel : Doctor
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
