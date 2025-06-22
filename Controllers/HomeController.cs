using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DummyK8sApp.Models;

namespace DummyK8sApp.Controllers;

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

    [HttpPost]
        public IActionResult Index(string username, string password)
        {
            TempData["Username"] = username;
            //TempData["Email"] = email;
            //TempData["Password"] = Guid.NewGuid().ToString().Substring(0, 8);
            TempData["Password"] = password;
            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            ViewBag.Username = TempData["Username"];
            //ViewBag.Email = TempData["Email"];
            ViewBag.Password = TempData["Password"];
            return View();
        }

}
