using System.Collections.Generic;

namespace Webshop.Models.ProductList
{
    public class ProductIndexModel
    {
        public IEnumerable<ProductIndexListingModel> Products { get; set; }
        public ProductIndexListingModel Product { get; set; }
    }
}
