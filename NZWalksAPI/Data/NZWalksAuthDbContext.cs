using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data;

public class NZWalksAuthDbContext : IdentityDbContext
{
    public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> dbcontextOptions) : base(dbcontextOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var roles = GetRoles();
        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }

    private List<IdentityRole> GetRoles()
    {
        var readerId = "dad9b26d-8947-4ea0-a172-5c7277da42b5";
        var writerId = "5aa5d75-ec8f-494f-b228-8bea2bc42f2d";

        return new List<IdentityRole>
        {
            new IdentityRole
            {
               Id = readerId,
               ConcurrencyStamp = readerId,
               Name = "Reader",
               NormalizedName = "Reader".ToUpper()
            },
            new IdentityRole
            {
                Id = writerId,
                ConcurrencyStamp = writerId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
            }
        };
    }
}