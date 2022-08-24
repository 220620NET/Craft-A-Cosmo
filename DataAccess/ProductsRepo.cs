using DataAccess.Entities;
using CustomExceptions;
using Models;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;
 
public class ProductsRepo : IProductsDAO
{
    private readonly p3dbContext _context;

    public ProductsRepo(p3dbContext context)
    {
        _context = context;
    }

    public List<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public bool AddProduct()
    {
        return false;
    }

    public bool GetProductDescription()
    {
        return false;
    }

    public bool GetProductPrice()
    {
        return false;
    }

    public bool GetProductName()
    {
        return false;
    }

    public bool GetProductImage()
    {
        return false;
    }

    public bool GetProductByCategory()
    {
        return false;
    }     

    public bool GetProductsByPriceRange()
    {
        return false;
    }               
}