using AuthorizationApiProject.DataAccess.Entities;
using AuthorizationApiProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AuthorizationApiContext : IdentityDbContext<AppUser>
{

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

    public AuthorizationApiContext(DbContextOptions<AuthorizationApiContext> options)
        : base(options)
    {
    }

}
