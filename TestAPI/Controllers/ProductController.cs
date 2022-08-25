using CustomExceptions;
using Models;
using Services;
using DataAccess.Entities;

namespace Controllers;

public class ProductController
{
    private readonly ProductServices _service;

    public ProductController(ProductServices service)
    {
        _service = service;
    }

    public IResult GetAllProducts()
    {
        List<Product> productList = _service.GetAllProducts();
        return Results.Accepted("/GetAllProducts", productList);
    }

    public IResult GetProductsByCategory(string category)
    {
        try
        {   
            List<Product> productList = _service.GetProductsByCategory(category);
            return Results.Ok(productList);
        }
        catch(CategoryNotFound)
        {
            return Results.NotFound("No products match this specified category.");
        }               
        catch(NoProductsMatchThisDescription)
        {
            return Results.NotFound("No products exist within the specified price range.");
        }
        catch(ResourceNotFound)
        {
            return Results.NotFound("Something went wrong with this request.");
        }
    } 

    public IResult GetProductsByPriceRange(int priceMin, int priceMax)
    {
        try
        {   
            List<Product> productList = _service.GetProductsByPriceRange(priceMin, priceMax);
            return Results.Ok(productList);
        }
        catch(IncorrectEntry)
        {
            return Results.NotFound("Maximum price must exceed minimum price.");
        }        
        catch(NoNegatives)
        {
            return Results.NotFound("Please enter a positive number.");
        }        
        catch(NoProductsMatchThisDescription)
        {
            return Results.NotFound("No products exist within the specified price range.");
        }
        catch(ResourceNotFound)
        {
            return Results.NotFound("Something went wrong with this request.");
        }
    }     
}