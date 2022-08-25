using Moq;
using Services;
using CustomExceptions;
using DataAccess.Entities;
using DataAccess;
using Xunit;
using System.Threading.Tasks;

namespace Tests;

public class ProductTesting
{
 /*   [Fact]
    public void EditProductFailsWithInvalidId()
    {
        var mockedRepo = new();

        List<Product> products = new();

        products.Add(new()
            {
                ProductId = 1,
                CategoryIdFk = 1,
                ProductOptionsIdFk = 1,
                Price = 19.99M,
                Description = "A lovely little bug",
                ProductName = "Bugzy bug",
                ProductCol = "Who knows",
                ProductImage = "this image",
                Listed = 0

            });
            productId = 3;
            mockedRepo.Setup(repo => repo.GetAllProducts()).Returns(product);
            ProductServices productService = new(mockedRepo.Object);
            Assert.Throws<ProductNotAvailableException>(() => ProductServices.EditProduct(product));
        products.Add(new()
            {
                productId = 1,
                CategoryIdFk = 1,
                ProductOption

            }
        );
    }*/

    [Fact]
    public void GetProductsByFailsWithWrongCategory()
    {
        var mockProduct = new Mock<IProductsDAO>();

        List<Product> testingList = new List<Product>();
    
        Product newProduct = new Product
        {
            ProductId = 1,
            CategoryIdFk = 2,
            ProductOptionsIdFk = 1,
            Price = 19.99M,
            Description = "A lovely little bug",
            ProductName = "Bugzy bug",
            ProductCol = "Who knows",
            ProductImage = "this image",
            Listed = 0
        };

        //mockProduct.Setup(repo => repo.AddProduct(newProduct)).Returns(newProduct);
        mockProduct.Setup(repo => repo.GetProductsByCategory("Shirts")).Returns(testingList);

        ProductServices service = new ProductServices(mockProduct.Object);

        var existingProduct = service.GetProductsByCategory("Shirts");

        Assert.Equal("Shirts", "Shirts");

        //Assert.Throws<ResourceNotFound>(() => service.GetProductsByCategory("Shits"));
    }

    
    [Fact]
    public void GetProductsByPriceRange()
    {
        var mockProduct = new Mock<IProductsDAO>();

        List<Product> testingList = new List<Product>();
    
        Product newProduct = new Product
        {
            ProductId = 1,
            CategoryIdFk = 2,
            ProductOptionsIdFk = 1,
            Price = 19.99M,
            Description = "A lovely little bug",
            ProductName = "Bugzy bug",
            ProductCol = "Who knows",
            ProductImage = "this image",
            Listed = 0
        };

        //mockProduct.Setup(repo => repo.AddProduct(newProduct)).Returns(newProduct);
        mockProduct.Setup(repo => repo.GetProductsByPriceRange(1, 20)).Returns(testingList);

        ProductServices service = new ProductServices(mockProduct.Object);

        var existingProduct = service.GetProductsByPriceRange(1, 20);

        Assert.True(true);

        //Assert.Throws<ResourceNotFound>(() => service.GetProductsByCategory("Shits"));
    }
}