using BackendServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendServer.Database
{
    public class DatabaseService
    {
        private readonly TodoItemsContext _dbContext;

        public DatabaseService(TodoItemsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TodoItem>> RetrieveTodoItems()
        {
            return await _dbContext.Items.ToListAsync();
        }

        public async Task AddTodoItems(IEnumerable<TodoItem> items)
        {
            await _dbContext.AddRangeAsync(items);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddMockedItems()
        {
            var list = new List<TodoItem>() {
                new TodoItem() {
                    Person = "Pedro",
                    Item = "Work"
                },
                new TodoItem() {
                    Person = "Carol", 
                    Item = "Work Harder"
                }
            };
            await _dbContext.Items.AddRangeAsync(list);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveItems(IEnumerable<int> items)
        {
            _dbContext.Items.RemoveRange(_dbContext.Items.Where(_ => items.Contains(_.Id)));
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveItems()
        {
            _dbContext.Items.RemoveRange(_dbContext.Items);
            await _dbContext.SaveChangesAsync();
        }
    }
}
