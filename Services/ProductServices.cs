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

    /*
    public List<Product> GetProductByCategory(string category)
    {
        try
        {
            Products = _productsRepo.GetProductsByCategory(category);
            if(category == null)
            {
                throw new ResourceNotFound();
            }
            return _productsRepo.GetProductsByCategory(category);
        }
        catch (ResourceNotFound)
        {
            throw;
        }
    }*/
}