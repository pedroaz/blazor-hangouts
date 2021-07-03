using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RazorComponents.Models
{
    public class TodoItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("person")]
        public string Person { get; set; }

        [JsonPropertyName("item")]
        public string Item { get; set; }
    }
}
