using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StomatoloskaPoliklinika.Models;

namespace StomatoloskaPoliklinika.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<StomatoloskaPoliklinika.Models.Pacijent> Pacijent { get; set; } = default!;
    public DbSet<StomatoloskaPoliklinika.Models.UgovoreniSastanak> UgovoreniSastanak { get; set; } = default!;
    public DbSet<StomatoloskaPoliklinika.Models.Stomatolog> Stomatolog { get; set; } = default!;
}

