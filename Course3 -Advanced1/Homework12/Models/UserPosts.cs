using System;
using System.Collections.Generic;
using System.Text;

namespace Homework12.Models
{
    public class UserPosts
    {
        public User User { get; set; }

        public List<Post> Posts { get; set; }
    }
}
