using Services;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;

namespace Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly CartServices _service;
    public CartController(CartServices service)
    {
        this._service = service;
    }

    [HttpGet("{userID}")]
    public ActionResult<List<Cart>> Get(int userID)
    {
        List<Cart> Carts  = this._service.findCartsByUserID(userID);
        return Carts.Count > 0 ? Ok(Carts) : NoContent();
    }
}