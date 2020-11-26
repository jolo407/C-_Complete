
using Microsoft.AspNetCore.Mvc;
using Calendar.Models;
using System.Collections.Generic;
using System.Linq;

namespace Calendar.Controllers 
{

    public class ApiController : Controller
    {

        private DataContext dbContext;

        public ApiController(DataContext db)
        {
            this.dbContext = db; 
        }


        [HttpPost]
        public IActionResult SaveTask([FromBody] Task theTask)
        {


            //save it
                dbContext.Tasks.Add(theTask);
                dbContext.SaveChanges();

            //return
            return Json(theTask);
        }
        [HttpGet]
        public IActionResult GetTasks()
        {
           var allTasks = dbContext.Tasks.ToList();
           return Json(allTasks);
        }

        [HttpDelete]
        public IActionResult DeleteTask(int id)
        {
            Task theTask = dbContext.Tasks.Find(id); // find the task with that id
            dbContext.Tasks.Remove(theTask);
            dbContext.SaveChanges();

            return Ok();
        }

        public IActionResult Test()
        {
            return Content("Hello FSD01");
        }
    }
}