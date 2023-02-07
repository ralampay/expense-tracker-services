namespace ExpenseTrackerServices.Operations;

public class ValidateSaveCategory
{
    private Dictionary<string, object> payload;

    public Dictionary<string, List<string>> Errors { get; private set; }

    public ValidateSaveCategory(Dictionary<string, object> payload)
    {
        this.payload = payload;

        this.Errors = new Dictionary<string, List<string>>();
        Errors.Add("name", new List<string>());
    }

    public bool HasErrors()
    {
        bool ans = false;

        if(Errors["name"].Count > 0) {
            ans = true;
        }

        return ans;
    }

    public bool HasNoErrors()
    {
        return !HasErrors();
    }

    public void Execute()
    {
        // Name validation
        if(!payload.ContainsKey("name")) {
            Errors["name"].Add("name is required");
        }
    }
}