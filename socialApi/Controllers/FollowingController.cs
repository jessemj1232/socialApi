using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using socialApi.Models;

namespace socialApi.Controllers
{

    [Route("api/user/following")]
    [ApiController]
    public class FollowingController : ControllerBase
    {
        private readonly FollowingContext _context;
        public FollowingController (FollowingContext context)
        {
            _context = context;
            if(_context.Follows.Count() == 0)
            {
                _context.Follows.Add(new Following { FollowingID = 69420 });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult<List<Following>> GetAll()
        {
            return _context.Follows.ToList();
        }
        [HttpGet("{id}", Name = "GetFollowers")]
        public ActionResult<Following> GetByID(int id)
        {
            var item = _context.Follows.Find(id);
            if (item == null ) { return NotFound(); }
            return item;
        }

        //Add Follower
        [HttpPost]
        public IActionResult Create (Following newFollower)
        {
            _context.Follows.Add(newFollower);
            _context.SaveChanges();
            return CreatedAtRoute("GetFollowers", new { id = newFollower.FollowingID }, newFollower);
        }


        //Delete Follower
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var follower = _context.Follows.Find(id);
            if (follower == null) { return NotFound(); }
            _context.Follows.Remove(follower);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
