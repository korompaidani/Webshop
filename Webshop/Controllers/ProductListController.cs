using CommonServices.Authentication;
using Webshop.Models.ProductList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Globalization;
using System.Linq;
using WebshopData;
using WebshopData.Models;

namespace Webshop.Controllers
{
    public class ProductListController : Controller
    {
        private IWebshopItems _context;
        IAuthenticationService _authenticationService;

        public ProductListController(IWebshopItems context, IAuthenticationService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            ViewBag.CategorySelectList = new SelectList(_context.GetAllCategory().Select(o => o.CategoryKind), "CategoryKind");
            var products = _context.GetAll();

            var resultList = products
                .Select(result => new ProductIndexListingModel
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
            
            var model = new ProductIndexModel()
            {
                Products = resultList
            };

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _context.DeleteProduct(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateNewEntry(string itemName,
            string description, string price, string CategoryKind)
        {
            int id = _context.GetMaxProductId() + 1;
            Category cat = _context.GetCategoryByName(CategoryKind);

            var email = _authenticationService.GetLoggedUser().Key;
            var userName = _authenticationService.GetLoggedUser().Value;

            Person pers = _context.GetPerson(email);
            if (pers == null)
            {
                pers = new Person();
                pers.Email = email;
                pers.PersonName = userName;
            }

            float pric = 0;
            try
            {
                pric = float.Parse(price, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch
            {
                //TODO: error handler must be implemented
            }

            _context.Add(new WebshopData.Models.Product
            {
                Id = id,
                ItemName = itemName,
                Description = description,
                Price = pric,
                UploadTime = DateTime.Now,
                Category = cat,
                Person = pers
            });

            return RedirectToAction("Index");
        }
    }
}
