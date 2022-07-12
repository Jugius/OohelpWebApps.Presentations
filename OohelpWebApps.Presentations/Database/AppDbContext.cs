using Microsoft.EntityFrameworkCore;
using OohelpWebApps.Presentations.Database.Dto;

namespace OohelpWebApps.Presentations.Database;

public class AppDbContext : DbContext
{
    public DbSet<PresentationDto> Presentations { get; set; }
    public DbSet<BoardDto> Boards { get; set; }
    public DbSet<PoiDto> Pois { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }
}
