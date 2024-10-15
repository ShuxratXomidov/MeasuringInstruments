using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MeasuringInstruments.Controllers;

public class DeviceController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
