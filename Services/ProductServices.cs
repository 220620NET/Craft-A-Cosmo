using DataAccess.Entities;
using CustomExceptions;
using Models;
using System.Data.SqlClient;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class ProductServices
{
    private readonly IProductsDAO _productsRepo;
	//private readonly IItemsDAO _itemsRepo;

    public ProductServices(IProductsDAO productsRepo/*IItemsDAO itemsRepo*/)
    {
        _productsRepo = productsRepo;
        //_itemsRepo = itemsRepo;
    }
    
    
    public List<Product> GetAllProducts()
    {
        return _productsRepo.GetAllProducts();
    }

    
    public List<Product> GetProductsByCategory(string category)
    {
        List<Product> productList = _productsRepo.GetProductsByCategory(category);
        if(productList == null)
        {
            throw new ResourceNotFound();
        }
        return _productsRepo.GetProductsByCategory(category);
    }
    
    public List<Product> GetProductsByPriceRange(int priceMin, int priceMax)
    {
        List<Product> productList = _productsRepo.GetProductsByPriceRange(priceMin, priceMax);
        if(productList == null)
        {
            throw new ResourceNotFound();
        }

        return _productsRepo.GetProductsByPriceRange(priceMin, priceMax);
    }
}