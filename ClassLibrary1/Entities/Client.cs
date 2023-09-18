using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary1.Entities
{
    public class Client : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} can only contain up to {1} characters.")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} can only contain up to {1} characters.")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} can only contain up to {1} characters.")]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        public string ImageURL { get; set; }

        public string ImageFullPath { get; set; }
    }
}
