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
    [Fact]
    public void EditProductFailsWithInvalidId()
    {
        var mockedRepo = new();

        List<Product> products = new();

        products.Add(new()
            {
                productId = 1,
                categoryIdFk = 1,
                productOptionsIdFk = 1,
                price = 19.99,
                description = "A lovely little bug",
                productName = "Bugzy bug",
                productCol = "Who knows",
                productImage = "this image",
                Listed = 0

            });
            productId = 3;
            mockedRepo.Setup(repo => repo.GetAllProducts()).Returns(product);
            ProductServices productService = new(mockedRepo.Object);
            Assert.Throws<ProductNotAvailableException>(() => ProductServices.EditProduct(product));
    }
}