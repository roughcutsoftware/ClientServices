using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace ClientServices.Dtos
{
    public class TodoItemDto : ITodoItem
    {
        public long? UserId { get; set; }
        public long? Id { get; set; }
        public string Title { get; set; }
        public bool? Completed { get; set; }

        // added to support .NET MAUI - todo: create possible bool-to-string converter
        public string CompletedString
        {
            get
            {
                return Completed == true ? "Yes" : "No";
            }
        }
    }
}
