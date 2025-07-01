using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;
using System.Runtime.ConstrainedExecution;

namespace NZWalksAPI.Data;

public class NZWalksDbContext : DbContext
{
    public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var difficulties = GetDifficulties();
        modelBuilder.Entity<Difficulty>().HasData(difficulties);

        var regions = GetRegions();
        modelBuilder.Entity<Region>().HasData(regions);
    }

    private List<Region> GetRegions()
    {
        return new List<Region>
        {
            new Region
            {
                Id = new Guid("5c6d4f7b-0377-4575-82c9-8ed97507ead4"),
                Name = "Bay of Plenty",
                Code = "BOP"
            },
            new Region
            {
                Id = new Guid("2c3ebf81-c52c-472b-b77e-902b3ea59c82"),
                Name = "Wellington",
                Code = "WGN",
                ImageUrl = "Wellington.jpg"
            },
            new Region
            {
                Id = new Guid("d022a2e6-a5d3-4908-aeb5-93e8b03469bf"),
                Name = "Nelson",
                Code = "NL"
            },
            new Region
            {
                Id = new Guid("44e543d5-ac41-4714-9ae9-16a23dd1b79b"),
                Name = "Southland",
                Code = "STL",
                ImageUrl = "STL.png"
            },
        };
    }

    private List<Difficulty> GetDifficulties()
    {
        return new List<Difficulty>
        {
            new Difficulty
            {
                Id =  new Guid("a22691a3-3b18-4ce0-9381-2f782cde9cce"),
                Name = "Easy"
            },
            new Difficulty
            {
                Id =  new Guid("5162e552-93a2-4e35-a264-c9d1987a08f1"),
                Name = "Medium"
            },
            new Difficulty
            {
                Id =  new Guid("f9f564ef-ea12-4dcd-8dc4-34a9afb74119"),
                Name = "Hard"
            }
        };

    }
}