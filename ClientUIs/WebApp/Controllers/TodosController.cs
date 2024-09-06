using ClientServices.Base;
using ClientServices.Dtos;
using ClientServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TodosController : Controller
    {
        ViewModelBase<TodoItemDto> _viewModel = new ViewModelBase<TodoItemDto>(TodoAction.BaseUrl);

        // GET: TodosController
        public async Task<ActionResult> Index()
        {

            // get list of TodoItemDtos
            List<TodoItemDto> todosList = await _viewModel.GetListAsync(TodoAction.GetTodos);

            // check if the todosList is not null
            if (todosList is { Count: >= 1 })
            {
                // pass the todosList to the view
                return View(todosList);
            }

            //else
            //{
            //    return View();
            //}
            //
            return View();
        }

        //// GET: TodosController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: TodosController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TodosController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TodosController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TodosController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TodosController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TodosController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
