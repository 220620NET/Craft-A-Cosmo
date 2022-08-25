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
    //public List<Product> GetProductDescription(string userInput);
    //public Product GetProductPrice(int productId);
    public Product GetProductByProductId(int productId);
    public List<Product> GetProductsByCategory(string category);
    public List<Product> GetProductsByPriceRange(int priceMin, int priceMax);

}
