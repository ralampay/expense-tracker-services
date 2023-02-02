namespace ExpenseTrackerServices.Configuration;

public class ApplicationContext
{
    public List<Dictionary<string, object>> expenseItems;

    private static ApplicationContext instance = null;

    public static ApplicationContext Instance
    {
        get {
            if(instance == null) {
                instance = new ApplicationContext();
            }

            return instance;
        }
    }

    public ApplicationContext()
    {
        this.expenseItems = new List<Dictionary<string, object>>();

        Dictionary<string, object> item1 = new Dictionary<string, object>();
        item1.Add("id", 1);
        item1.Add("name", "X");
        item1.Add("amount", 100);

        Dictionary<string, object> item2 = new Dictionary<string, object>();
        item2.Add("id", 2);
        item2.Add("name", "Y");
        item2.Add("amount", 200);

        expenseItems.Add(item1);
        expenseItems.Add(item2);
    }
}