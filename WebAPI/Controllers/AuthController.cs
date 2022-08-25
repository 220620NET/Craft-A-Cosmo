using Microsoft.AspNetCore.Mvc;
using Services;
using DataAccess;
using DataAccess.Entities;
namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _auth;
    private readonly IUserRepo _repo;
    public AuthController(AuthService auth,IUserRepo repo)
    {
        _repo = repo;
        _auth = auth;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post(User newUser)
    {
        User you = await _auth.Register(newUser);
        return Created($"user/{you.UserId}", you);
    }

    [HttpPost("loginU")]
    public async Task<ActionResult<User>> PostLoginUsername(User newUser)
    {
        User you = await _auth.LoginWithUsername(newUser.Username,newUser.Password);
        return Created($"user/{you.UserId}", you);
    }
    [HttpPost("loginP")]
    public async Task<ActionResult<User>> PostLoginEmail(User newUser)
    {
        User you = await _auth.LoginWithEmail(newUser.Email, newUser.Password);
        return Created($"user/{you.UserId}", you);
    }
}
