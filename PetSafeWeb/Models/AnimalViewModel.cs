using ClassLibrary1.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PetSafeWeb.Models
{
    public class AnimalViewModel : Animal
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
