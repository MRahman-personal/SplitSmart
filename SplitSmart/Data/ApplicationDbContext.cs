using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SplitSmart.Models;

namespace SplitSmart.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseModel>()
            .HasOne(e => e.GroupModel)
            .WithMany(g => g.ExpenseModels)
            .HasForeignKey(e => e.ExpenseGroupName)
            .HasPrincipalKey(g => g.GroupName);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<GroupModel> GroupModels { get; set; }
    public DbSet<ExpenseModel> ExpenseModels { get; set; }
    public DbSet<PaymentModel> PaymentModels { get; set; }
}

