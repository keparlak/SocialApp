using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppForIbb.Ent
{
    public class Follows
    {
        public int following_user_id { get; set; }
        public int followed_user_id { get; set; }
        public DateTime createdAt { get; set; }
    }
}
