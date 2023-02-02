namespace ExpenseTrackerServices.Services;

using System.Collections.Generic;
using ExpenseTrackerServices.Interfaces;
using ExpenseTrackerServices.Configuration;

public class ExpenseItemsApplicationContextService : IExpenseItemsService
{
    public List<Dictionary<string, object>> GetAll()
    {
        return ApplicationContext.Instance.expenseItems;
    }

    public void Save(Dictionary<string, object> hash)
    {
        ApplicationContext.Instance.expenseItems.Add(hash);
    }
}