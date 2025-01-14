using Entities;

namespace UseCases;

public class TodoListManager
{
    private readonly ITodoItemRepository _repository;
    public TodoListManager(ITodoItemRepository todoItemRepository)
    {
        _repository = todoItemRepository;
    }

    public IEnumerable<TodoItem> GetTodoItems()
    {
        return _repository.GetItems();
    }

    public TodoItem? GetTodoItem(int id)
    {
        return _repository.GetById(id);
    }

    public void AddTodoItem(TodoItem item)
    {
        _repository.Add(item);
    }

    public void UpdateTodoItem(TodoItem item)
    {
        _repository.Update(item);
    }

    public void MarkComplete(int id)
    {
        MarkCompleteState(id, true);
    }

    public void MarkInComplete(int id)
    {
        MarkCompleteState(id, false);
    }

    private void MarkCompleteState(int id, bool state)
    {
        var item = _repository.GetById(id);
        if (item != null)
        {
            item.IsCompleted = state;
            _repository.Update(item);
        }
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}
