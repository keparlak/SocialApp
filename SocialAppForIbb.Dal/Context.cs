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
        public Context(DbContextOptions <Context> options):base(options) {
        
        }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, primary keys, etc.

            modelBuilder.Entity<Follow>().HasKey(f => new
            {
                f.FollowingUserId,
                f.FollowedUserId
            });
            // Configure soft delerte using IsDeleted property

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);

            // Configure the relationship between Follow and User entities

            modelBuilder.Entity<Follow>()
                .HasOne(f=> f.FollowedUser)
                .WithMany() //Modify if there is a collection property on User pointing back to Follow
                .HasForeignKey(f => f.FollowingUserId)
                .OnDelete(DeleteBehavior.Restrict); // Configure the desired delete behavior

            base.OnModelCreating(modelBuilder);
        }

    }
}
