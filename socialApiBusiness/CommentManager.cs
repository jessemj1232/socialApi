using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using socialApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace socialApiBusiness
{

    public class CommentManager : ControllerBase
    {
        public CommentContext _context;
        public CommentManager(CommentContext context)
        {
            _context = context;
            if (_context.Comments.Count() == 0)
            {
                _context.Comments.Add(new Comment { CommentID = 69420 });
                _context.SaveChanges();
            }
        }

        public List<Comment> getAll()
        {
            return _context.Comments.ToList();
        }

        public Comment GetByID(int id)
        {
            var item = _context.Comments.Find(id);
            //Todo: Make this line work
            // if (item == null) { return NotFound(); }
            return item;
        }

        public void Create(Comment newComment)
        {
            _context.Comments.Add(newComment);
            _context.SaveChanges();
        }

        public NoContentResult Delete(int id)
        {
            var comment = _context.Comments.Find(id);
            //Figure this line out
            //if (comment == null) { return NotFound(); }
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
