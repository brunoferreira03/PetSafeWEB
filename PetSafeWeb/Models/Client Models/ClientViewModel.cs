using ClassLibrary1.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PetSafeWeb.Models.ClientModels
{
    public class ClientViewModel : Client
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
