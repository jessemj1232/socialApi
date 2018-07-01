using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialApi.Models
{
    public class Following
    {
        public int ID { get; set; }
        public int FollowingID { get; set; }
        public bool IsComplete { get; set; }
        //need date followed
    }
}
