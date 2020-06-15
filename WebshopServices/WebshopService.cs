using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebshopData;
using WebshopData.Models;

namespace WebshopServices
{
    public class WebshopService : IWebshopItems
    {
        private WebshopContext _context;
        
        public WebshopService(WebshopContext context)
        {
            _context = context;
        }

        public void Add(Product newProduct)
        {
            _context.Add(newProduct);
            _context.Database.OpenConnection();
            try
            {
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Products ON");
                _context.SaveChanges();
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Products OFF");
            }
            finally
            {
                _context.Database.CloseConnection();
            }
        }

        public void Add(Person newPerson)
        {
            _context.Add(newPerson);
        }
        
        public Category GetCategoryByName(string categoryName)
        {
            var category = GetAllCategory().FirstOrDefault(a => a.CategoryKind == categoryName);
            if (category != null)
            {
                return category;
            }
            else
            {
                return new Category
                {
                    CategoryKind = categoryName
                };
            }
        }

        public void DeleteProduct(int id)
        {
            if(_context.Products.Any(item => item.Id == id))
            {
                var product = _context.Products
                .FirstOrDefault(item => item.Id == id);

                if (product != null)
                {
                    var res = _context.Products.Remove(product);
                    _context.SaveChanges();
                }                
            }            
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                .Include(a => a.Category)
                .Include(a => a.Person);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _context.Categories;
        }

        public IEnumerable<Product> GetAllDataByPerson(string email)
        {
            return _context.Products.Where(a => a.Person.Email == email)
                .Include(a => a.Category)
                .Include(a => a.Person);
        }

        public int GetMaxProductId()
        {
            try
            {
                return _context.Products.Max(p => p.Id);
            }
            catch
            {
                //TODO: Must be handlend in an own error handler which hasn't been existed yet
                return 0;
            }            
        }

        public Person GetPerson(string email)
        {
            return _context.Persons
                .FirstOrDefault(person => person.Email == email);
        }        
    }
}
