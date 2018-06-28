using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using socialApi.Models;

namespace socialApi.Controllers
{

    [Route("api/user/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentContext _context;
        public CommentController(CommentContext context)
        {
            _context = context;
            if (_context.Comments.Count() == 0)
            {
                _context.Comments.Add(new Comment { CommentID = 69420 });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult<List<Comment>> GetAll()
        {
            return _context.Comments.ToList();
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
