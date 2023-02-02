namespace ExpenseTrackerServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ExpenseTrackerServices.Configuration;

[ApiController]
[Route("expense_items")]
public class ExpenseItemsController : ControllerBase
{
    public ExpenseItemsController()
    {
    }

    /*
    Exercise 2:
    1. Create your own POST endpoint to fetch an object from a curl request
    2. Build the object in its native data type.
    3. Add it to your "database"
    4. Verify that it saved by requesting all data from your Index()
    */
    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        int id = int.Parse(hash["id"].ToString());
        string name = hash["name"].ToString();
        float amount = float.Parse(hash["amount"].ToString());

        Console.WriteLine("Id: " + id);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Amount: " + amount);

        Dictionary<string, object> newItem = new Dictionary<string, object>();
        newItem.Add("id", id);
        newItem.Add("name", name);
        newItem.Add("amount", amount);

        ApplicationContext.Instance.expenseItems.Add(newItem);

        Dictionary<string, object> message = new Dictionary<string, object>();
        message.Add("message", "Ok");

        return Ok(message);
    }

    // Requirement: Endpoint to return all expense items
    // URL: GET /expense_items
    [HttpGet("")]
    public IActionResult Index()
    {
        /*
        {
            "expense_items": [
                { "id": 1, "name": "X", "amount": 100 },
                { "id": 2, "name": "Y", "amount": 200 },
            ]
        }
        */
        Dictionary<string, object> data = new Dictionary<string, object>();

        Console.WriteLine("Instance: " + ApplicationContext.Instance);
        data.Add("expense_items", ApplicationContext.Instance.expenseItems);

        return Ok(data);
    }

    // Requirement: Endpoint to return a single expense item based on id
    // URL: GET /expense_items/{id} <-- Path Parameter
    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        /*
        Exercise 1: 
        1. Create a webapi project for your project
        2. Choose a model that you will create the Index() and Show() services for
        3. The data is a member of the controller
        4. Index should return all transactions
        5. Show should return a single object given id
        */
        return Ok("Show Expense Item: " + id);
    }
}