using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using UseCases;

namespace TodoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TodoListManager _listManager;

    public HomeController(TodoListManager listManager, ILogger<HomeController> logger)
    {
        _logger = logger;
        _listManager = listManager;
    }

    public IActionResult Index()
    {
        var todoItems = _listManager.GetTodoItems();
        return View(new TodoListViewModel
        {
            Items = todoItems.Select(ti => new Item
            {
                Id = ti.Id,
                Text = ti.Text,
                IsCompleted = ti.IsCompleted
            })
        });
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View(nameof(Add));
    }

    [HttpPost]
    public IActionResult Add(Item item)
    {
        _listManager.AddTodoItem(new TodoItem
        {
            Text = item.Text,
            IsCompleted = false
        });

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update([FromRoute] int id)
    {
        var item = _listManager.GetTodoItem(id);
        return View(nameof(Update), new Item
        {
            Id = item!.Id,
            Text = item.Text,
            IsCompleted = item.IsCompleted
        });
    }

    [HttpPost]
    public IActionResult Update([FromRoute] int id, [FromForm] Item item)
    {
        _listManager.UpdateTodoItem(new TodoItem
        {
            Id = id,
            Text = item.Text,
            IsCompleted = Request.Form["IsCompleted"] == "on" ? true : false
        });

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult MarkComplete([FromRoute] int id, [FromBody] MarkCompleteRequest request)
    {
        if (request.IsCompleted)
        {
            _listManager.MarkComplete(id);
        }
        else
        {
            _listManager.MarkInComplete(id);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete([FromRoute] int id)
    {
        _listManager.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
