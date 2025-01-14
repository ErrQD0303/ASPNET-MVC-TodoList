using Entities;
using UseCases;
using Xunit;

namespace TestProject;

public class UnitTest1Test
{
    [Fact]
    public void CreateTodoItem_And_SetCompleted_Test()
    {
        // Arrange
        var mockRepository = new InMemoryTodoItemRepository();
        var todoListManager = new TodoListManager(mockRepository);

        var todoItem = new TodoItem { Id = 1, Text = "Test Item", IsCompleted = false };

        // Act
        todoListManager.AddTodoItem(todoItem);
        todoListManager.MarkComplete(1);

        // Assert
        Assert.True(todoListManager.GetTodoItems().First().IsCompleted);
        Assert.Equal("Test Item", todoListManager.GetTodoItems().First().Text);
    }
}