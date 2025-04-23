using Microsoft.AspNetCore.Mvc;
using Project_WebAPI_1.Services;

namespace Project_WebAPI_1.Controllers;

[ApiController]
[Route("api/todo")]
public class ToDoController : ControllerBase
{
    private readonly ToDoService _toDoService;

    public ToDoController(ToDoService toDoService)
    {
        _toDoService = toDoService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var tasks = _toDoService.GetAllTasks();
        return Ok(tasks);
    }
}