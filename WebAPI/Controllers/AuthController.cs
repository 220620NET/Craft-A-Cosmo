using Microsoft.AspNetCore.Mvc;
using Services;
using DataAccess.Entities;
namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _auth;
    public AuthController(AuthService auth)
    {
        _auth = auth;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post(User newUser)
    {
        User you = await _auth.Register(newUser);
        return Created($"user/{you.UserId}", you);
    }
    
}
