using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public bool? IsCompleted { get; set; }
    }
}