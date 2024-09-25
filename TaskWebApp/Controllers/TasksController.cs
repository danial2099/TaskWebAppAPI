using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskWebApp.Models;
using TaskWebApp.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        public readonly ApplicationDBContext context;
        public TasksController(ApplicationDBContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public List<TaskModel> GetTask()
        {
            return context.Tasks.OrderByDescending(x => x.Id).ToList();
        }

        [HttpGet("{Id}")]
        public IActionResult GetTask(int Id)
        {
            var Task = context.Tasks.Find(Id);
            if (Task == null)
            {
                return NotFound();
            }
            return Ok(Task);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskCreate Taskcreate)
        {
            //should submitted valid data.
            var otherTask = context.Tasks.FirstOrDefault(c => c.PICEmail == Taskcreate.PICEmail);
            if (otherTask != null)
            {
                ModelState.AddModelError("Email", "Email has already been used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);

            }

            var Task = new TaskModel
            {
                TaskName = Taskcreate.TaskName,
                TaskDescription = Taskcreate.TaskDescription,
                CustomerName = Taskcreate.CustomerName,
                ManDays = Taskcreate.ManDays,
                StartDate = Taskcreate.StartDate,
                AddDays = Taskcreate.AddDays,
                Expectdate = Taskcreate.Expectdate,
                PICEmail = Taskcreate.PICEmail,
                Status = Taskcreate.Status,
                CompletionDate = Taskcreate.CompletionDate,
                Remarks = Taskcreate.Remarks,
                LastDateComs = Taskcreate.LastDateComs,

            };

            context.Tasks.Add(Task);
            context.SaveChanges();


            return Ok(Task);
        }

        [HttpPut("{Id}")]
        public IActionResult EditUser(int id, TaskCreate TaskCreate)
        {

            var otherTask = context.Tasks.FirstOrDefault(c => c.Id != id && c.PICEmail == TaskCreate.PICEmail);
            if (otherTask != null)
            {
                ModelState.AddModelError("Email", "Email has already been used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);

            }

            var Task = context.Tasks.Find(id);
            if (Task == null)
            {
                return NotFound();
            }
            Task.TaskName = TaskCreate.TaskName;
            Task.TaskDescription = TaskCreate.TaskDescription;
            Task.CustomerName = TaskCreate.CustomerName;
            Task.ManDays = TaskCreate.ManDays;
            Task.StartDate = TaskCreate.StartDate;
            Task.AddDays = TaskCreate.AddDays;
            Task.Expectdate = TaskCreate.Expectdate;
            Task.PICEmail = TaskCreate.PICEmail;
            Task.Status = TaskCreate.Status;
            Task.CompletionDate = TaskCreate.CompletionDate;
            Task.Remarks = TaskCreate.Remarks;
            Task.LastDateComs = TaskCreate.LastDateComs;

            context.SaveChanges();

            return Ok(Task);
        }


        [HttpDelete("{Id}")]
        public IActionResult DeleteTask(int id)
        {
            var Task = context.Tasks.Find(id);
            if (Task == null)
            {
                return NotFound();

            }

            context.Tasks.Remove(Task);
            context.SaveChanges();

            return Ok();
        }
    }
}
