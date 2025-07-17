using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DummyK8sApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyK8sApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DummyK8s _db;

    public HomeController(ILogger<HomeController> logger, DummyK8s db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string username, string password)
    {
        // Check if user exists
        var user = _db.UserDummy.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user == null)
        {
            TempData["Error"] = "User not found.";
            return RedirectToAction("Index");
        }

        TempData["Username"] = user.Username;
        TempData["Password"] = user.Password;
        TempData["Name"] = user.Name;
        TempData["Email"] = user.Email;
        return RedirectToAction("Result");
    }

    public IActionResult Result()
    {
        ViewBag.Username = TempData["Username"];
        ViewBag.Password = TempData["Password"];
        ViewBag.Name = TempData["Name"];
        ViewBag.Email = TempData["Email"];
        return View();
    }
}
