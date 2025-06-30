using System.ComponentModel.DataAnnotations;

// Add the required package for PostgreSQL
// Command: dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

public class UserDummy
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    // Add other properties as needed
}