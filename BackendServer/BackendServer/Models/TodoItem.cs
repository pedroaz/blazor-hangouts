using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendServer.Models
{
    [Table("todo_items")]
    public class TodoItem
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("person")]
        public string Person { get; set; }

        [Column("item")]
        public string Item { get; set; }
    }
}
