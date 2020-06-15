using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebshopData.Models
{
    public class Category
    {
        [Key]
        public string CategoryKind { get; set; }
    }
}
