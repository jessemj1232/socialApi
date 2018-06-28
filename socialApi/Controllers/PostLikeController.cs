using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using socialApi.Models;

namespace socialApi.Controllers
{

    [Route("api/user/post/postlike")]
    [ApiController]
    public class PostLikeController : ControllerBase
    {
        private readonly PostLikeContext _context;
        public PostLikeController(PostLikeContext context)
        {
            _context = context;
            if (_context.PostLikes.Count() == 0)
            {
                _context.PostLikes.Add(new PostLike { ID = 69420 });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult<List<PostLike>> GetAll()
        {
            return _context.PostLikes.ToList();
        }
        [HttpGet("{id}", Name = "GetPostLikes")]
        public ActionResult<PostLike> GetByID(int id)
        {
            var item = _context.PostLikes.Find(id);
            if (item == null) { return NotFound(); }
            return item;
        }

        //Add CommentLike
        [HttpPost]
        public IActionResult Create(PostLike newPostLike)
        {
            _context.PostLikes.Add(newPostLike);
            _context.SaveChanges();
            return CreatedAtRoute("GetPostLikes", new { id = newPostLike.ID }, newPostLike);
        }


        //Delete CommentLike
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var follower = _context.PostLikes.Find(id);
            if (follower == null) { return NotFound(); }
            _context.PostLikes.Remove(follower);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
