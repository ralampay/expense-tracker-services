namespace ExpenseTrackerServices.Operations;

using ExpenseTrackerServices.Models;

public class BuildExpenseItemFromHash
{
    private Dictionary<string, object> hash;

    public BuildExpenseItemFromHash(Dictionary<string, object> hash)
    {
        this.hash = hash;
    }

    public ExpenseItem Execute()
    {
        ExpenseItem item = new ExpenseItem();

        if(hash.ContainsKey("id"))
        {
            item.Id = int.Parse(hash["id"].ToString());
        }

        item.Name = hash["name"].ToString();

        item.Amount = float.Parse(hash["amount"].ToString());

        return item;
    }
}