namespace ExpenseTrackerServices.Operations;

public class ValidateSaveExpenseItems
{
    private Dictionary<string, object> payload;

    public Dictionary<string, List<string>> Errors { get; private set; }

    public ValidateSaveExpenseItems(Dictionary<string, object> payload)
    {
        this.payload = payload;

        this.Errors = new Dictionary<string, List<string>>();
        Errors.Add("name", new List<string>());
        Errors.Add("amount", new List<string>());
    }

    public bool HasErrors()
    {
        bool ans = false;

        if(Errors["name"].Count > 0) {
            ans = true;
        }

        if(Errors["amount"].Count > 0) {
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
        int id = int.Parse(payload["id"].ToString());

        // Name validation
        if(!payload.ContainsKey("name")) {
            Errors["name"].Add("name is required");
        }

        // Amount validation
        if(!payload.ContainsKey("amount")) {
            Errors["amount"].Add("amount is required");
        } else {
            try {
                float amount = float.Parse(payload["amount"].ToString());

                if(amount <= 0) {
                    Errors["amount"].Add("amount should be positive");
                }
            } catch(FormatException e) {
                Errors["amount"].Add("invalid format for amount " + payload["amount"].ToString());
            }
        }
    }
}