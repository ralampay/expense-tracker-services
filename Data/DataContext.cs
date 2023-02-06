namespace ExpenseTrackerServices.Data;

using Microsoft.EntityFrameworkCore;
using ExpenseTrackerServices.Models;

public class DataContext : DbContext
{
    public DbSet<ExpenseItem> ExpenseItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {

    }
}