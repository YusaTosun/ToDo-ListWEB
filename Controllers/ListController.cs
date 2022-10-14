using denemeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace denemeShop.Controllers
{
    public class List : Controller
    {
        TodoListDBContext _db;

        public List(TodoListDBContext db)
        {
            _db = db;
        }

        public IActionResult ListTable()
        {
            
            List<ToDoListTable> ToDoListTables = _db.ToDoListTables.ToList();


            return View(ToDoListTables);
        }

        public IActionResult AddTask()
        {


            return View();
        }

        [HttpPost]
        public IActionResult AddTask(ToDoListTable _ToDoListTable)
        {
            _db.ToDoListTables.Add(_ToDoListTable);
            _db.SaveChanges();

            return RedirectToAction("ListTable");
        }

        public IActionResult Edit(int id)
        {
          ToDoListTable _ToDoListTable =  _db.ToDoListTables.Find(id);

            return View(_ToDoListTable);
        }


        [HttpPost]
        public IActionResult Edit(ToDoListTable _ToDoListTable)
        {
            
            _db.ToDoListTables.Update(_ToDoListTable);
            _db.SaveChanges();
            return RedirectToAction("ListTable");
        }

        public IActionResult Delete(int id)
        {
            ToDoListTable _ToDoListTable = _db.ToDoListTables.Find(id);
            _db.ToDoListTables.Remove(_ToDoListTable);
            _db.SaveChanges();
            return RedirectToAction("ListTable");
        }
    }
}
