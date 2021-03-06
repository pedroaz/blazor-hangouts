using BackendServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendServer.Database
{
    public class TodoItemsContext : DbContext
    {
        public DbSet<TodoItem> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=c:\Users\Pedro\Desktop\dev\BlazorHangouts\BackendServer\BackendServer\SqlLite\DemoDatabase.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
