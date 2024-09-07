using ClientServices.Base;
using ClientServices.Dtos;
using ClientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.NetFx
{
    public partial class Todos : System.Web.UI.Page
    {
        // stub out view model for now
        private ViewModelBase<TodoItemDto> viewModel;

        // https://stackoverflow.com/questions/44385376/asp-net-webforms-with-async-await
        // https://learn.microsoft.com/en-us/aspnet/web-forms/overview/performance-and-caching/using-asynchronous-methods-in-aspnet-45
        protected void Page_Load(object sender, EventArgs e)
        {
            // 
            this.viewModel = new ViewModelBase<TodoItemDto>(TodoAction.BaseUrl);

            //
            RegisterAsyncTask(new PageAsyncTask(GetTodosListAsync));

        }

        // https://github.com/RickAndMSFT/Async-ASP.NET/blob/master/WebAppAsync/WebAppAsync/GizmosAsync.aspx.cs
        private async Task GetTodosListAsync()
        {
            //
            var items = await viewModel.GetListAsync(TodoAction.GetTodos);

            //
            DataListTodos.DataSource = items.Take(7);
            DataListTodos.DataBind();
        }

    }
}