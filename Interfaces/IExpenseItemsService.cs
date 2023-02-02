namespace ExpenseTrackerServices.Interfaces;

public interface IExpenseItemsService
{
    public List<Dictionary<string, object>> GetAll();

    public void Save(Dictionary<string, object> hash);
}