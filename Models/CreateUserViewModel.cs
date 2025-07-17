using System.ComponentModel.DataAnnotations;

namespace DummyK8sApp.Models;

public class CreateUserViewModel
{
    [Required]
    public string Name { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
