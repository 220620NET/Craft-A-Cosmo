using Models;
using System.Data.SqlClient;
using DataAccess.Entities;

namespace DataAccess;

public interface IProductsDAO
{
    public List<Product> GetAllProducts();
    public bool AddProduct();
    public bool DeleteProducts();
    public bool EditProducts();
    public bool GetProductDescription();
    public bool GetProductPrice();
    public bool GetProductName();
    public bool GetProductImage();
    public bool GetProductByCategory();
    public bool GetProductsByPriceRange();
}
