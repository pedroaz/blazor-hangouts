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
    }
}
