using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskWebApp.Services;
using TaskWebApp.Models;

namespace TaskWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly ApplicationDBContext context;
        public UserController(ApplicationDBContext context) 
        {
            this.context = context;
            
        }

        [HttpGet]
        public List<Users>GetUser()
        {
            return context.User.OrderByDescending(x => x.Id).ToList();
        }

        [HttpGet ("{Id}")]
        public IActionResult GetUser(int Id) 
        { 
            var user = context.User.Find(Id);
            if (user == null) 
            { 
                return NotFound();  
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(UserCreate usercreate) 
        {
            //should submitted valid data.
            var otheruser = context.User.FirstOrDefault(c => c.Email == usercreate.Email);
             if (otheruser != null)
            {
                ModelState.AddModelError("Email", "Email has already been used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);

            }

            var user = new Users
            {
                Name = usercreate.Name,
                Email = usercreate.Email,
                PhoneNumber = usercreate.PhoneNumber ?? "",
                ICNumber = usercreate.ICNumber

            };

            context.User.Add(user);
            context.SaveChanges();


            return Ok(user);
        }

        [HttpPut("{Id}")]
        public IActionResult EditUser (int id , UserCreate userCreate) 
        {

            var otherUser = context.User.FirstOrDefault(c => c.Id !=id &&  c.Email == userCreate.Email);
            if (otherUser != null)
            {
                ModelState.AddModelError("Email", "Email has already been used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);

            }   

            var user = context.User.Find(id);
            if (user == null)
            {
                return NotFound();  
            }

            user.Name = userCreate.Name;
            user.Email = userCreate.Email;
            user.PhoneNumber = userCreate.PhoneNumber ?? "";
            user.ICNumber = userCreate.ICNumber;

            context.SaveChanges();

            return Ok(user);
        }


        [HttpDelete("{Id}")]
        public IActionResult DeleteUser (int id) 
        { 
            var user = context.User.Find(id);
            if (user == null) 
            {
                return NotFound();

            }

            context.User.Remove(user);
            context.SaveChanges();
            
            return Ok();
        }
    }
}
