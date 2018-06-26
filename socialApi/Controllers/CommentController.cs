using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using socialApi.Models;

namespace socialApi.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentController(CommentContext context)
        {
            _context = context;

            if (_context.Comments.Count() == 0)
            {
                _context.Comments.Add(new Comment { Content = "Ur mum" });
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

        //Add new Comment
        [HttpPost]
        public IActionResult Create(Comment newComment)
        {
            _context.Comments.Add(newComment);
            _context.SaveChanges();

            return CreatedAtRoute("GetComments", new { id = newComment.UserID }, newComment);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comment = _context.Comments.Find(id);


            if (comment == null) { return NotFound(); }

            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return NoContent();
        }


    }

}
 