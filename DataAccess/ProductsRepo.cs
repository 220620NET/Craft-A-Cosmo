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

    public bool DeleteProducts()
    {
        return false;
    }
    public Product GetProductByProductId(int productId) 
    {
        return _context.Products.FirstOrDefault(productToFind => productToFind.ProductId == productId) ?? throw new ResourceNotFound("No product with this ID exists.");
    }

    public Product EditProduct(Product product)
    {
        try {
                Product? p =_context.Products.FirstOrDefault(t => t.ProductId == product.ProductId);
                p.CategoryIdFk = product.CategoryIdFk != 0 ? product.CategoryIdFk : p.CategoryIdFk;
                p.ProductOptionsIdFk = product.ProductOptionsIdFk !=0 ? product.ProductOptionsIdFk : p.ProductOptionsIdFk;
                p.Price = product.Price != 0 ? product.Price : p.Price;
                p.Description = product.Description != "" ? product.Description : p.Description;
                p.ProductName = product.ProductName != "" ? product.ProductName : p.ProductName;
                p.ProductCol = product.ProductCol != "" ? product.ProductCol : p.ProductCol;
                p.ProductImage = product.ProductImage != "" ? product.ProductImage : p.ProductImage;
                p.Listed = product.Listed != 0 ? product.Listed : p.Listed;
                return p ?? throw new ProductNotAvailableException();

            }
            catch (ArgumentNullException)
            {
                throw new ProductNotAvailableException();
            }

        }    

  /*  public List<Product> GetProductDescription(string userInput)
    {
        List<Product> productList = new List<Product>();

        IEnumerable<Product> productQuery =
                (from Products in _context.Products
                where Products.Description.Any(userInput)
                select Products).ToList<Product>();

        foreach(Product product in productQuery)
        {
            productList.Add(product);
        }

        return productList;
    }*/
    //search * products where description includes "user inputted text"

  /*  public Product GetProductPrice(int productId)
    {
        Product productInstance = _context.Find(productId);
        return productInstance.Price;
    }*/

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