using Moq;
using NUnit.Framework;
using SampleProductApplication.Models;
using SampleProductApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProductTest
{
    
    public class AddTest
    {
        [Test]
        public void AddSampleTest()
        {
            Product testProd = new Product()
            {
                Name = "Food66 stuff",
                Category = "food",
                Price = 12.5,
                Quantity = 5,
                Pic = "images/food.jpg",
                Description = "yummy food"
            };
            Mock<ProductRepo> mockRepo = new Mock<ProductRepo>();
            mockRepo.Setup(x => x.Add(testProd));
            ProductService service = new ProductService(mockRepo.Object);
            Product product = new Product()
            {
                Name = "Food66 stuff",
                Category = "food",
                Price = 12.5,
                Quantity = 5,
                Pic = "images/food.jpg",
                Description = "yummy food"
            };
            //Act
            var resultuser = service.ProductAdd(product);
            //Assert
            Assert.IsNotNull(resultuser);
        }
        //public void AddSampleTest()
        //{
        //    Mock<ProductRepo> mockRepo = new Mock<ProductRepo>();
        //    mockRepo.Setup(x => x.Add(new Product()
        //    {
        //        Name = "Food66 stuff",
        //        Category = "food",
        //        Price = 12.5,
        //        Quantity = 5,
        //        Pic = "images/food.jpg",
        //        Description = "yummy food"
        //    }));
        //    ProductService service = new ProductService(mockRepo.Object);
        //    Product product = new Product()
        //    {
        //        Name = "Food66 stuff",
        //        Category = "food",
        //        Price = 12.5,
        //        Quantity = 5,
        //        Pic = "images/food.jpg",
        //        Description = "yummy food"
        //    };
        //    //Act
        //    var resultuser = service.ProductAdd(product);
        //    //Assert
        //    Assert.IsNotNull(resultuser);
        //}

    }
}
