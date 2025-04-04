using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using menus.Models;

namespace menus.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Photos ()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Descripcion1(int? id, string tipo)
    {
        // Puedes usar ViewBag o un modelo para pasar datos a la vista
        ViewBag.Id = id;
        ViewBag.Tipo = tipo;

        return View();
    }
}
