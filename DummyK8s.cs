using Microsoft.EntityFrameworkCore;

public class DummyK8s : DbContext
{
    public DummyK8s(DbContextOptions<DummyK8s> options) : base(options) { }

    public DbSet<UserDummy> UserDummy { get; set; }
}