using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using socialApi.Models;

namespace socialApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new User { Name = "Ur mum" });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _context.Users.ToList();
        }
        [HttpGet("{id}", Name = "GetUsers")]
        public ActionResult<User> GetByID(int id)
        {
            var item = _context.Users.Find(id);
            if (item == null) { return NotFound(); }
            return item;
        }
        [HttpPost]
        public IActionResult Create(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return CreatedAtRoute("GetUsers", new { id = newUser.UserID }, newUser);

        }
    }
}