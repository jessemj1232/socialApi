using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialApi.Models
{
    public class CommentLike
    {
        public int ID { get; set; }
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public bool IsComplete { get; set; }
        //need dateLiked
    }
}
