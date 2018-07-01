using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using socialApiBusiness;
using socialApi.Models;

namespace socialApi.Controllers
{

    [Route("api/user/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
       
        public CommentController()
        {
           
        }
        [HttpGet]
        public ActionResult<List<Comment>> GetAll()
        {
            return CommentManager.GetAll();
        }
        [HttpGet("{id}", Name = "GetComments")]
        public ActionResult<Comment> GetByID(int id)
        {
            var item = _context.Comments.Find(id);
            if (item == null) { return NotFound(); }
            return item;
        }

        //Add CommentLike
        [HttpPost]
        public IActionResult Create(Comment newComment)
        {
            _context.Comments.Add(newComment);
            _context.SaveChanges();
            return CreatedAtRoute("GetCommentL", new { id = newComment.CommentID }, newComment);
        }


        //Delete CommentLike
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var follower = _context.Comments.Find(id);
            if (follower == null) { return NotFound(); }
            _context.Comments.Remove(follower);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
