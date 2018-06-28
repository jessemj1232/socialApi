using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using socialApi.Models;

namespace socialApi.Controllers
{

    [Route("api/user/comment/commentlike")]
    [ApiController]
    public class CommentLikeController : ControllerBase
    {
        private readonly CommentLikeContext _context;
        public CommentLikeController(CommentLikeContext context)
        {
            _context = context;
            if (_context.CommentLikes.Count() == 0)
            {
                _context.CommentLikes.Add(new CommentLike { CommentID = 69420 });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult<List<CommentLike>> GetAll()
        {
            return _context.CommentLikes.ToList();
        }
        [HttpGet("{id}", Name = "GetCommentLikes")]
        public ActionResult<CommentLike> GetByID(int id)
        {
            var item = _context.CommentLikes.Find(id);
            if (item == null) { return NotFound(); }
            return item;
        }

        //Add CommentLike
        [HttpPost]
        public IActionResult Create(CommentLike newCommentLike)
        {
            _context.CommentLikes.Add(newCommentLike);
            _context.SaveChanges();
            return CreatedAtRoute("GetCommentLikes", new { id = newCommentLike.CommentID }, newCommentLike);
        }


        //Delete CommentLike
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var follower = _context.CommentLikes.Find(id);
            if (follower == null) { return NotFound(); }
            _context.CommentLikes.Remove(follower);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
