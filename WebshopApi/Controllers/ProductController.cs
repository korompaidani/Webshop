using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebshopData;
using WebshopData.Models;
using Microsoft.AspNetCore.Mvc;
using WebshopApi.Models;

namespace WebshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IWebshopItems _context;

        public ProductController(IWebshopItems context)
        {
            _context = context;
        }

        private IEnumerable<ProductDTO> Get()
        {
            var products = _context.GetAll();

            var resultList = products
                .Select(result => new ProductDTO
                {
                    Id = result.Id,
                    ItemName = result.ItemName,
                    Description = result.Description,
                    Price = result.Price.ToString(),
                    UploadTime = result.UploadTime.ToString(),
                    Category = result.Category.CategoryKind,
                    PersonName = result.Person.PersonName,
                    PersonEmail = result.Person.Email
                });

            return resultList;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = Get();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost]
        public ActionResult Post([FromBody] NewProductDTO value)
        {
            int id = _context.GetMaxProductId() + 1;
            Category cat = _context.GetCategoryByName(value.Category);
            Person pers = _context.GetPerson(value.PersonEmail);
            if (pers == null)
            {
                return BadRequest(value.PersonEmail);
            }

            float pric = 0;
            try
            {
                pric = float.Parse(value.Price, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch
            {
                return BadRequest(value.Price);
            }

            _context.Add(new WebshopData.Models.Product
            {
                Id = id,
                ItemName = value.ItemName,
                Description = value.Description,
                Price = pric,
                UploadTime = DateTime.Now,
                Category = cat,
                Person = pers
            });

            return Ok();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _context.DeleteProduct(id);
        }       
    }
}
