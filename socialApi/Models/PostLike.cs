using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialApi.Models
{
    public class PostLike
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public bool IsComplete { get; set; }
        //Need dateLiked
    }
}
