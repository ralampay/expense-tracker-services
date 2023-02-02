namespace ExpenseTrackerServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ExpenseTrackerServices.Configuration;
using ExpenseTrackerServices.Interfaces;
using ExpenseTrackerServices.Services;

[ApiController]
[Route("expense_items")]
public class ExpenseItemsController : ControllerBase
{
    /*
    Exercise 3:
    1. Create an actual model of a class representing one of your data. Make sure its under a namespace for "Models"
    2. Refactor everything so it uses the model instance instead of Dictionary
    3. Create a service (a. Interface b. ApplicationContext implementing service) that implements the following:
        - GetAll()
        - Save(Model object) where Model is your model
        - Find(int id) returns a single instance of the model.
        - Delete(int id)
    4. Use the service in your controller and create test scripts to test the endpoint functionality
    */
    private readonly IExpenseItemsService _expenseItemsService;

    public ExpenseItemsController(IExpenseItemsService expenseItemsService)
    {
        _expenseItemsService = expenseItemsService;
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

        _expenseItemsService.Save(newItem);

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

        data.Add("expense_items", _expenseItemsService.GetAll());

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