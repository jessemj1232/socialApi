using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialApi.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string RoleType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public char Gender { get; set; }
        public string Occupation { get; set; }
        public bool IsComplete { get; set; }
    }
}
