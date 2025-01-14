using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using UseCases;

namespace Infrastructure
{
    public class SQLServerTodoItemRepository<T> : ITodoItemRepository where T : WebContext<T>
    {
        private readonly SQLServerWebContext _context;

        public SQLServerTodoItemRepository(SQLServerWebContext context)
        {
            _context = context;
        }

        public void Add(TodoItem item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null) throw new InvalidOperationException("Item not found");
            _context.TodoItems.Remove(item);
            _context.SaveChanges();
        }

        public TodoItem? GetById(int id)
        {
            return _context.TodoItems.Find(id);
        }

        public IEnumerable<TodoItem> GetItems()
        {
            return [.. _context.TodoItems];
        }

        public void Update(TodoItem item)
        {
            var existingItems = _context.TodoItems.Find(item.Id);
            if (existingItems == null) return;
            existingItems.Text = item.Text ?? existingItems.Text;
            existingItems.IsCompleted = item.IsCompleted ?? existingItems.IsCompleted;
            _context.Update(existingItems);
            _context.SaveChanges();
        }
    }
}