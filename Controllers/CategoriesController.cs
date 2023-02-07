namespace ExpenseTrackerServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ExpenseTrackerServices.Configuration;
using ExpenseTrackerServices.Interfaces;
using ExpenseTrackerServices.Services;
using ExpenseTrackerServices.Operations;
using ExpenseTrackerServices.Models;

[ApiController]
[Route("categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        ValidateSaveCategory validator = new ValidateSaveCategory(hash);
        validator.Execute();

        if (validator.HasErrors())
        {
            return UnprocessableEntity(validator.Errors);
        }
        else
        {
            BuildCategoryFromHash builder = new BuildCategoryFromHash(hash);
            Category item = builder.Execute();

            _categoriesService.Save(item);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Ok");

            return Ok(message);
        }
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();

        data.Add("categories", _categoriesService.GetAll());

        return Ok(data);
    }

    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        var category = _categoriesService.FindById(id);
        return Ok(category);
    }
}