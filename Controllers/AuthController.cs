using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace MeasuringInstruments.Controllers;

public class AuthController : Controller
{
    private readonly DataContext dbContext;

    public AuthController(DataContext dataContext)
    {
        this.dbContext = dataContext;
    }

    [HttpGet]
    [Route("[controller]/[action]")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Route("[controller]/[action]")]
     public IActionResult SendRegister(User user)
    {
        
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

       
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Email),
            new Claim("OtherProperties", "Example Role")
        };

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        AuthenticationProperties properties = new AuthenticationProperties()
        {
            AllowRefresh = true,
            IsPersistent = true
        };
        
        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

        return RedirectToAction("Index","User");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [Route("[controller]/[action]")]
     public IActionResult SendLogin(User odam)
    {
        var user=dbContext.Users.FirstOrDefault(u=>u.Email == odam.Email && u.Password == odam.Password);

        

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, odam.Email),
            new Claim("FirstName", user.FirstName ),
            new Claim("OtherProperties", "Example Role")
        };

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        AuthenticationProperties properties = new AuthenticationProperties()
        {
            AllowRefresh = true,
            IsPersistent = true
        };
        
        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);


        return RedirectToAction("Index", "User");

    }

      public IActionResult Logout()
      {
        HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
      }
}