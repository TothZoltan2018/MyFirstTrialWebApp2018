using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{

    public class TodoController : Controller
    {
        public ActionResult ToDoList()
        {
            ViewBag.Message = "Ezt a " + nameof(TodoController) + "-bol irattam ki.";
            return View(MyDb.Lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name, bool isDone)
        {
            if (!string.IsNullOrEmpty(name))
            {//Ha van adat a parameterben
                //adatok mentese es vissza az indexre
                MyDb.Lista.Add(new TodoItem() { Name = name, Done = isDone });

                return RedirectToAction("TodoList");
            }
            //todo: mivel a adat nem valid, itt kene a hibauzenettel valamit kezdeni
            //(kiadni az ugyfel fele)
            return View();
        }
    }
}