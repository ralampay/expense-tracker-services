namespace ExpenseTrackerServices.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ExpenseItem> ExpenseItems { get; set; }
}