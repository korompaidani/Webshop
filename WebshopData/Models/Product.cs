using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebshopData.Models
{
    public class Product
    {           
        public int Id { get; set; }

        [Required][MinLength(6, ErrorMessage = "Minimum 6 characters are required")]
        public string ItemName { get; set; }
        
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public DateTime UploadTime { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        [Required]
        public virtual Person Person { get; set; }
    }
}
