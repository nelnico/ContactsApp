using Contacts.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data;

public class DataContext : IdentityDbContext<AppUser>
{
    private readonly IServiceProvider _serviceProvider;

    public DataContext(DbContextOptions<DataContext> options, IServiceProvider serviceProvider) : base(options)
    {
        _serviceProvider = serviceProvider;
    }

    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable("People");

        base.OnModelCreating(modelBuilder);
    }
}