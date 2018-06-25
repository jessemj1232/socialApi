using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialApi.Models
{
    public class Comment
    {
        public int UserID { get; set; }
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsComplete { get; set; }
        //nneed datecreated and datemodifed
    }
}
