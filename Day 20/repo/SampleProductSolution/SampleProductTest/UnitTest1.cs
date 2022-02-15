using NUnit.Framework;
using SampleProductApplication.Models;
using SampleProductApplication.Services;
using Moq;

namespace SampleProductTest
{
    public class Tests
    {
        IRepo<int, Product> _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new ProductRepo();
        }

        [Test]
        public void Test1()
        {
            Mock<ProductRepo> mockRepo = new Mock<ProductRepo>();
            mockRepo.Setup(x => x.Get(4)).Returns(new Product { 
                Id = 4, 
                Name = "Food stuff",
            Category = "food",
            Price = 12.5,
            Quantity = 5,
            Pic = "images/food.jpg",
            Description = "yummy food"
            });
            ProductService service = new ProductService(mockRepo.Object);
            Product product = new Product() {Id = 4};
            //Act
            var resultuser = service.ProductCheck(product);
            //Assert
            Assert.IsNotNull(resultuser);
        }
    }
}