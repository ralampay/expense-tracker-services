namespace ExpenseTrackerServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

[ApiController]
[Route("expense_items")]
public class ExpenseItemsController : ControllerBase
{

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

        List<Dictionary<string, object>> expenseItems = new List<Dictionary<string, object>>();

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

        data.Add("expense_items", expenseItems);
        String payload = JsonSerializer.Serialize(data);

        return Ok(payload);
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