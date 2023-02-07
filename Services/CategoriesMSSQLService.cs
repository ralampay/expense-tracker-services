namespace ExpenseTrackerServices.Services;

using System.Collections.Generic;
using ExpenseTrackerServices.Interfaces;
using ExpenseTrackerServices.Models;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerServices.Data;
using ExpenseTrackerServices.Operations;

public class CategoriesMSSQLService : ICategoriesService
{
    private readonly DataContext _dataContext;

    public CategoriesMSSQLService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Category FindById(int id)
    {
        return _dataContext.Categories.SingleOrDefault(o => o.Id == id);
    }

    public List<Dictionary<string, object>> GetAll()
    {
        List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

        List<Category> items = _dataContext.Categories.ToList<Category>();

        foreach(Category item in items) {
            Dictionary<string, object> hash = new Dictionary<string, object>();
            hash.Add("id", item.Id);
            hash.Add("name", item.Name);

            data.Add(hash);
        }

        return data;
    }

    public void Save(Dictionary<string, object> hash)
    {
        var builder = new BuildCategoryFromHash(hash);
        Category item = builder.Execute();

        this.Save(item);
    }

    public void Save(Category item)
    {
        if(item.Id == null || item.Id == 0) {
            _dataContext.Categories.Add(item);
        } else {
            Category temp = this.FindById(item.Id);
            temp.Name = item.Name;
        }

        _dataContext.SaveChanges();
    }
}