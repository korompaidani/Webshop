using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models.ProductList
{
    public class ProductIndexListingModel
    {
        public int Id { get; set; }        
        public string ItemName { get; set; }
        public string Description { get; set; }        
        public string Price { get; set; }
        public string UploadTime { get; set; }
        public string Category { get; set; }
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
    }
}
