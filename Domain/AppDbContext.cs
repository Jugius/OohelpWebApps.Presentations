using Microsoft.EntityFrameworkCore;
using OohelpWebApps.Presentations.Domain.Data;

namespace OohelpWebApps.Presentations.Domain;

public class AppDbContext : DbContext
{
    public DbSet<PresentationDto> Presentations { get; set; }
    public DbSet<BoardDto> Boards { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }
}
