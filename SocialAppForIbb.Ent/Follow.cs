using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppForIbb.Ent
{
    public class Follow
    {
        public int FollowingUserId { get; set; }
        public int FollowedUserId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Relationships
        public User FollowingUser { get; set; }
        public User FollowedUser { get; set; }
    }
}
