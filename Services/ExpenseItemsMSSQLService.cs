namespace ExpenseTrackerServices.Services;

using System.Collections.Generic;
using ExpenseTrackerServices.Interfaces;
using ExpenseTrackerServices.Models;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerServices.Data;
using ExpenseTrackerServices.Operations;

public class ExpenseItemsMSSQLService : IExpenseItemsService
{
    private readonly DataContext _dataContext;
    private readonly ICategoriesService _categoriesService;

    public ExpenseItemsMSSQLService(DataContext dataContext, ICategoriesService _categoriesService)
    {
        _dataContext = dataContext;
        this._categoriesService = _categoriesService;
    }

    public ExpenseItem FindById(int id)
    {
        return _dataContext.ExpenseItems.SingleOrDefault(o => o.Id == id);
    }

    public List<Dictionary<string, object>> GetAll()
    {
        List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

        List<ExpenseItem> items = _dataContext.ExpenseItems.ToList<ExpenseItem>();

        foreach(ExpenseItem item in items) {
            Dictionary<string, object> hash = new Dictionary<string, object>();
            hash.Add("id", item.Id);
            hash.Add("name", item.Name);
            hash.Add("amountd", item.Amount);
            hash.Add("categoryId", item.CategoryId);

            data.Add(hash);
        }

        return data;
    }

    public void Save(Dictionary<string, object> hash)
    {
        var builder = new BuildExpenseItemFromHash(hash);
        ExpenseItem item = builder.Execute();

        this.Save(item);
    }

    public void Save(ExpenseItem item)
    {
        if(item.Id == null || item.Id == 0) {
            _dataContext.ExpenseItems.Add(item);
        } else {
            ExpenseItem temp = this.FindById(item.Id);
            temp.Name = item.Name;
            temp.Amount = item.Amount;
            temp.Category = _categoriesService.FindById(item.CategoryId);
        }

        _dataContext.SaveChanges();
    }
}