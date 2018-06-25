using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using socialApi.Models;


namespace socialApi.Controllers
{
    [Route("api/user/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostContext _context;
        public PostController(PostContext context)
        {
            _context = context;
            if (_context.Posts.Count() == 0)
            {
                _context.Posts.Add(new Post { Content = "Test Post" });
                _context.SaveChanges();
            }

        }
        [HttpGet]
        public ActionResult<List<Post>> GetAll()
        {
            return _context.Posts.ToList();
        }
        [HttpGet("{id}", Name = "GetPosts")]
        public ActionResult<Post> GetByID(int id)
        {
            var item = _context.Posts.Find(id);
            if (item == null) { return NotFound(); }
            return item;
        }

        //Add new Post
        [HttpPost]
        public IActionResult Create(Post newPost)
        {
            _context.Posts.Add(newPost);
            _context.SaveChanges();
            return NoContent();

        }

        //Update Post
        [HttpPut] 
        public IActionResult Update(int id, Post post)
        {
            var postId = _context.Posts.Find(id);
            if (postId == null) { return NotFound(); }
            postId.IsComplete = post.IsComplete;

            postId.Content = post.Content;

            _context.Posts.Update(post);
            _context.SaveChanges();
            return NoContent();
        }
        //Delete Post
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null) { return NotFound(); }
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
