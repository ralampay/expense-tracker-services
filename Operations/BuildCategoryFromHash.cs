namespace ExpenseTrackerServices.Operations;

using ExpenseTrackerServices.Models;

public class BuildCategoryFromHash
{
    private Dictionary<string, object> hash;

    public BuildCategoryFromHash(Dictionary<string, object> hash)
    {
        this.hash = hash;
    }

    public Category Execute()
    {
        Category item = new Category();

        if(hash.ContainsKey("id"))
        {
            item.Id = int.Parse(hash["id"].ToString());
        }

        item.Name = hash["name"].ToString();

        return item;
    }
}