using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppForIbb.Ent
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
