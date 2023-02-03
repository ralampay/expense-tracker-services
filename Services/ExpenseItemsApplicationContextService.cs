namespace ExpenseTrackerServices.Services;

using System.Collections.Generic;
using ExpenseTrackerServices.Interfaces;
using ExpenseTrackerServices.Configuration;
using ExpenseTrackerServices.Models;

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

    public void Save(ExpenseItem item)
    {
        Dictionary<string, object> hash = new Dictionary<string, object>();
        hash.Add("id", item.Id);
        hash.Add("name", item.Name);
        hash.Add("amount", item.Amount);

        ApplicationContext.Instance.expenseItems.Add(hash);
    }
}