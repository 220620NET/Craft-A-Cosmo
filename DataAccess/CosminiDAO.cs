using Models;
using System.Data.SqlClient;
using DataAccess.Entities;

namespace DataAccess;

public interface IProductsDAO
{
    public List<Product> GetAllProducts();
    public bool AddProduct();
    public bool DeleteProducts();
    public Product EditProduct(Product product);
    public List<Product> GetProductDescription(string userInput);
    public Product GetProductPrice(int productId);
    public bool GetProductName();
    public bool GetProductImage();
    public bool GetProductByCategory();
    public bool GetProductsByPriceRange();
    public Product GetProductByProductId(int productId);
}
