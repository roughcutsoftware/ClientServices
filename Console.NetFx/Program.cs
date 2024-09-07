using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientServices;
using ClientServices.Base;
using ClientServices.Dtos;

namespace Console.NetFx
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //
            ViewModelBase<TodoItemDto> _viewModel = new ViewModelBase<TodoItemDto>(TodoAction.BaseUrl);
            
            // cast items into a list of TodoItemDto
            var items = _viewModel.GetListAsync(TodoAction.GetTodos).Result;

            // check if the items is not null
            if (items != null)
            {
                if (items.Count >= 1)
                {
                    // disply top 5 items to console
                    foreach (var item in items.Take(5))
                    {
                        System.Console.WriteLine($"Id: {item.Id}, Name: {item.Title}, IsComplete: {item.CompletedString}");
                    }

                    System.Console.WriteLine("Data items loaded from ViewModel!");
                }
                else
                {
                    System.Console.WriteLine("Data items load failed");
                }
            }

            //
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();

        }

    }
}
