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

    public bool DeleteProduct()
    {
        return false;
    }

    public bool EditProduct()
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

    public List<Product> GetProductsByCategory(string category)
    {
        List<Product> productList = new List<Product>();

        if(category == null)
        {
            throw new ResourceNotFound();
        }

        Category categoryInstance = _context.Categories.FirstOrDefault(cat => cat.CategoryName == category) ?? throw new CategoryNotFound();         

        IEnumerable<Product> productQuery =
                (from Products in _context.Products
                where Products.CategoryIdFk == categoryInstance.CategoryId
                select Products).ToList<Product>();

        if(productQuery.Count() < 1)
        {
            throw new NoProductsMatchThisDescription();
        }

        foreach(Product product in productQuery)
        {
            productList.Add(product);
        }

        return productList;
    }     

    public List<Product> GetProductsByPriceRange(int priceMin, int priceMax)
    {
        List<Product> productList = new List<Product>();

        if(priceMin < 0)
        {
            throw new NoNegatives();
        }

        if(priceMin > priceMax)
        {
            throw new IncorrectEntry();
        }

        IEnumerable<Product> productQuery =
                (from Products in _context.Products
                where Products.Price > priceMin && Products.Price < priceMax
                select Products).ToList<Product>();

        if(productQuery.Count() < 1)
        {
            throw new NoProductsMatchThisDescription();
        }

        foreach(Product product in productQuery)
        {
            productList.Add(product);
        }

        return productList;
    }               
}