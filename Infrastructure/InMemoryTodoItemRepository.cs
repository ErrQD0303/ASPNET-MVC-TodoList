using Entities;
using UseCases;

namespace Infrastructure;

public class InMemoryTodoItemRepository : ITodoItemRepository
{
    private List<TodoItem> _items;
    private int _nextId = 1;

    public InMemoryTodoItemRepository()
    {
        _items = [];
    }

    public void Add(TodoItem item)
    {
        item.Id = _nextId++;
        _items.Add(item);
    }

    public void Delete(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item == null) throw new InvalidOperationException("Item not found");
        _items.Remove(item);
    }

    public TodoItem? GetById(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id)?.Clone();
    }

    public IEnumerable<TodoItem> GetItems()
    {
        return _items.Select(i => i.Clone());
    }

    public void Update(TodoItem item)
    {
        var existingItems = _items.FirstOrDefault(i => i.Id == item.Id);
        if (existingItems == null) return;
        existingItems.Text = item.Text ?? existingItems.Text;
        existingItems.IsCompleted = item.IsCompleted ?? existingItems.IsCompleted;
    }
}
