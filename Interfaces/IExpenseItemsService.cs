namespace ExpenseTrackerServices.Interfaces;

using ExpenseTrackerServices.Models;

public interface IExpenseItemsService
{
    public List<Dictionary<string, object>> GetAll();

    public void Save(Dictionary<string, object> hash);

    public void Save(ExpenseItem item);

    public ExpenseItem FindById(int id);
}