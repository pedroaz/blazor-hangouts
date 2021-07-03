using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSideTodoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Person { get; set; }

        public string Item { get; set; }
    }
}
