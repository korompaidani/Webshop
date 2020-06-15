using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using WebshopData;
using WebshopData.Models;
using Xunit;

namespace WebshopServices.Test
{
    public class WebshopServiceUnitTest
    {
        private WebshopService _webshopService;
        private WebshopContext _webshopContext;
        private Product _product;
        private Person _person;
        private Category _category;

        public WebshopServiceUnitTest()
        {            
            _webshopService = new WebshopService(_webshopContext);
            //_webshopContext = GetFullMockedContext();
        }

        [Fact]
        public void GetAllCategoryTest()
        {
            //var result = _webshopService.GetAllCategory();
        }

        // TODO: Most Create Interfaces behind of Models to have ability to test or find another way
        // to testing. I have read about test framework especially for entityFramework
        private WebshopContext GetFullMockedContext()
        {
            var categoryMock = new Mock<Category>();
            categoryMock.Setup(cat => cat.CategoryKind).Returns("");
            var collectionOfCategories = new List<Category>();
            collectionOfCategories.Add(categoryMock.Object);

            var PersonMock = new Mock<Person>();
            var collectionOfPersons = new List<Person>();
            collectionOfPersons.Add(PersonMock.Object);

            var productMock = new Mock<Product>();
            var collectionOfProducts = new List<Product>();
            collectionOfProducts.Add(productMock.Object);

            var dbsetOfCategory = (DbSet<Category>)(IEnumerable<Category>)collectionOfCategories;
            var dbsetOfPerson = (DbSet<Person>)(IEnumerable<Person>)collectionOfPersons;
            var dbsetOfProduct = (DbSet<Product>)(IEnumerable<Product>)collectionOfProducts;

            var contextMock = new Mock<WebshopContext>();
            contextMock.Setup(context => context.Categories).Returns(dbsetOfCategory);
            contextMock.Setup(context => context.Persons).Returns(dbsetOfPerson);
            contextMock.Setup(context => context.Products).Returns(dbsetOfProduct);

            return contextMock.Object;
        }
    }
}
