using Microsoft.EntityFrameworkCore;
using SocialAppForIbb.Ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppForIbb.Dal
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Follows> Follows { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
    }
}
