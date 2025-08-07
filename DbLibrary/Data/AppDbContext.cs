using Microsoft.EntityFrameworkCore;

namespace DbLibrary.Data;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<Group> Groups { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=dbLibrary123.db");
    }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>()
            .HasMany(g => g.Persons)
            .WithOne(p => p.Group)
            .HasForeignKey(p => p.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}