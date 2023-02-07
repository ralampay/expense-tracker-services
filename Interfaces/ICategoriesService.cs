namespace ExpenseTrackerServices.Interfaces;

using ExpenseTrackerServices.Models;

public interface ICategoriesService
{
    public List<Dictionary<string, object>> GetAll();

    public void Save(Dictionary<string, object> hash);

    public void Save(Category item);

    public Category FindById(int id);
}