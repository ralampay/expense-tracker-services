namespace ExpenseTrackerServices.Data;

using Microsoft.EntityFrameworkCore;
using ExpenseTrackerServices.Models;

public class DataContext : DbContext
{
    public DbSet<ExpenseItem> ExpenseItems { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseItem>()
            .HasOne(e => e.Category)
            .WithMany(c => c.ExpenseItems);
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {

    }
}