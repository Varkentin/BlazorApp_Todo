using BlazorApp_Todo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_Todo.Data.Repository
{
    public class SqlRepository : IRepository
    {
        private readonly DB _context;
        public SqlRepository(DB context)
        {
            _context = context;
        }

        public void AddTodo(string todoName)
        {
            TodoItem newItem = new TodoItem()
            {
                Title = todoName,
                IsDone = false
            };
            _context.TodoItems.Add(newItem);
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var deletedItem = _context.TodoItems.Find(id);

            if (deletedItem!= null)
            {
                _context.TodoItems.Remove(deletedItem);
                _context.SaveChanges();
                 
            }
        }

        public IEnumerable<TodoItem> GetAllItems()
        {
            return _context.TodoItems;
        }

        public void ValueChanged(TodoItem changedItem)
        {
            var item = _context.TodoItems.Attach(changedItem);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
