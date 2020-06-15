using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebshopData.Models
{
    public class Person
    {
        [Key]
        public string Email { get; set; }

        [MinLength(5, ErrorMessage = "Minimum 5 characters are required")]
        public string PersonName { get; set; }
    }
}
