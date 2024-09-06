using System;
using System.Collections.Generic;
using System.Text;

namespace ClientServices
{
    public class TodoAction
    {
        public static string BaseUrl = @"https://jsonplaceholder.typicode.com";

        public static string GetTodos = "/todos";
        public static string GetTodo = "/todos/{0}";

        public static string PostTodo = "/todos";
        public static string PutTodo = "/todos/{0}";

        public static string DeleteTodo = "/todos/{0}";


    }
}
