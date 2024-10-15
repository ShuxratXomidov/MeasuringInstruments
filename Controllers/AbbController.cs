using Microsoft.AspNetCore.Mvc;

namespace MeasuringInstruments.Controllers;

public class AbbController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}