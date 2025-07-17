using Microsoft.AspNetCore.Mvc;
using DummyK8sApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyK8sApp.Controllers;

public class UserController : Controller
{
    private readonly DummyK8s _db;
    public UserController(DummyK8s db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult CreateUser()
    {
        return View(new CreateUserViewModel());
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // Check if username or email already exists
        if (_db.UserDummy.Any(u => u.Username == model.Username || u.Email == model.Email))
        {
            ModelState.AddModelError("", "Username or Email already exists.");
            return View(model);
        }

        var user = new UserDummy
        {
            Name = model.Name,
            Email = model.Email,
            Username = model.Username,
            Password = model.Password
        };
        _db.UserDummy.Add(user);
        _db.SaveChanges();
        TempData["Success"] = "User created successfully!";
        return RedirectToAction("CreateUser");
    }

    [HttpGet]
    public IActionResult ListUsers(int page = 1, int pageSize = 10)
    {
        var totalUsers = _db.UserDummy.Count();
        var users = _db.UserDummy
            .OrderBy(u => u.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(u => new UserListViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Username = u.Username
            })
            .ToList();
        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling(totalUsers / (double)pageSize);
        return View(users);
    }
}

public class UserListViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
}
