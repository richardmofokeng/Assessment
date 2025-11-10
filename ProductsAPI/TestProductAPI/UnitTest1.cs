using ProductsAPI.Controllers;
using ProductsAPI.Models;
using ProductsAPI.Repositories.Interfaces;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace TestProductAPI
{
    public class UnitTest1
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductsController _controller;

        public UnitTest1()
        {
            _mockRepo = new Mock<IProductRepository>();
            _controller = new ProductsController(_mockRepo.Object);
        }

        [Fact]
        public void GetAll_ReturnsOkResult_WithListOfProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { ProductID = 1001, Name = "Laptop", Description = "Dev Spec Laptop", Price = 3200 },
                new Product { ProductID = 1002, Name = "Keyboard", Description = "Smartphone", Price = 1050 },
                 new Product { ProductID = 1003, Name = "Desktop", Description = "Smartphone", Price = 1400 },
                  new Product { ProductID = 1004, Name = "Monitor", Description = "Smartphone", Price = 3500 }
            };
            _mockRepo.Setup(repo => repo.GetAll()).Returns(products);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProducts = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Equal(2, returnProducts.Count());
        }
        [Fact]
        public void GetById_ProductExists_ReturnsOkResult()
        {
            // Arrange
            var product = new Product { ProductID = 1001, Name = "Laptop", Description = "Dev Spec Laptop", Price = 3200 };
            _mockRepo.Setup(repo => repo.GetById(1)).Returns(product);

            // Act
            var result = _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(1, returnProduct.ProductID);
        }

        [Fact]
        public void GetById_ProductDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetById(1)).Returns((Product?)null);

            // Act
            var result = _controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ValidProduct_ReturnsCreatedAtAction()
        {
            // Arrange
            var product = new Product { Name = "Tablet", Description = "12-inch Tablet", Price = 300 };
            var createdProduct = new Product { ProductID = 1, Name = "Tablet", Description = "12-inch Tablet", Price = 300 };
            _mockRepo.Setup(repo => repo.Add(product)).Returns(createdProduct);

            // Act
            var result = _controller.Create(product);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnProduct = Assert.IsType<Product>(createdAtActionResult.Value);
            Assert.Equal(1, returnProduct.ProductID);
        }

        [Fact]
        public void Update_ProductExists_ReturnsNoContent()
        {
            // Arrange
            var existingProduct = new Product { ProductID = 1, Name = "Laptop", Description = "Dev Spec Laptop", Price = 1500 };
            _mockRepo.Setup(repo => repo.GetById(1)).Returns(existingProduct);

            var updatedProduct = new Product { ProductID = 1, Name = "Laptop Pro", Description = "High-end Dev Spec Laptop", Price = 2000 };

            // Act
            var result = _controller.Update(1, updatedProduct);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockRepo.Verify(repo => repo.Update(updatedProduct), Times.Once);
        }

        [Fact]
        public void Update_ProductDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetById(1)).Returns((Product?)null);
            var updatedProduct = new Product { ProductID = 1, Name = "Laptop Pro", Description = "High-end Dev Spec Laptop", Price = 2000 };

            // Act
            var result = _controller.Update(1, updatedProduct);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ProductExists_ReturnsNoContent()
        {
            // Arrange
            var product = new Product { ProductID = 1001, Name = "Laptop", Description = "Dev Spec Laptop", Price = 3200 };
            _mockRepo.Setup(repo => repo.GetById(1)).Returns(product);

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockRepo.Verify(repo => repo.Delete(1), Times.Once);
        }

        [Fact]
        public void Delete_ProductDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetById(1)).Returns((Product?)null);

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
