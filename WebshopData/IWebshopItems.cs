using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebshopData.Models;

namespace WebshopData
{
    public interface IWebshopItems
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllDataByPerson(string email);
        IEnumerable<Category> GetAllCategory();

        void Add(Product newProduct);
        void DeleteProduct(int id);

        int GetMaxProductId();

        Person GetPerson(string email);        
        void Add(Person newPerson);
        Category GetCategoryByName(string categoryName);
    }
}
