using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeasuringInstruments.Conntrollers;

[Authorize]
[Route("[controller]")]

public class UserController : Controller
{
    private readonly DataContext dbContext;

    public UserController(DataContext dataContext)
    {
        this.dbContext = dataContext;
    }

    [Route("[action]")]
    public IActionResult Index()
    {
        List<User> users = new List<User>();
        users = dbContext.Users.ToList();

        return View(users);
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult Store(User user)
    {
        dbContext.Users.Add(user);
        dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public IActionResult Edit(int id)
    {
        var user = dbContext.Users.Find(id);

        return View(user);
    }

    [HttpPost]
    [Route("[action]/{id}")]
    public IActionResult Update(int id, User newuser)
    {
        var olduser = dbContext.Users.Find(id);

        olduser.FirstName = newuser.FirstName;
        olduser.LastName = newuser.LastName;
        olduser.PhoneNumber = newuser.PhoneNumber;
        olduser.Email = newuser.Email;
        olduser.Login = newuser.Login;
        olduser.Password = newuser.Password;
        olduser.PasswordConfirm = newuser.PasswordConfirm;

        dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public IActionResult Delete(int id)
    {
        var user = dbContext.Users.Find(id);
        dbContext.Users.Remove(user);
        dbContext.SaveChanges();
        
        return RedirectToAction("Index");
    }
}