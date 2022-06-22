using Microsoft.EntityFrameworkCore;
using Test.Payload;

namespace Test.Context;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    public DbSet<Contact> Contacts => Set<Contact>();
}

public class ContactTest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}