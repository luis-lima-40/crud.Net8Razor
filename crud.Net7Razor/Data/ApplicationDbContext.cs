using crud.Net7Razor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace crud.Net7Razor.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; } = default!;
    public DbSet<Interesses> Interesses { get; set; } = default!;
}
