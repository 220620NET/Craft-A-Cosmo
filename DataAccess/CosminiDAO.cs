using Models;
using System.Data.SqlClient;
using DataAccess.Entities;

namespace DataAccess;

public interface IProductsDAO
{
    public List<Product> GetAllProducts();
    public bool AddProduct();
    public bool DeleteProduct();
    public bool EditProduct();
    public bool GetProductDescription();
    public bool GetProductPrice();
    public bool GetProductName();
    public bool GetProductImage();
    public List<Product> GetProductsByCategory(string category);
    public List<Product> GetProductsByPriceRange(int priceMin, int priceMax);
}
