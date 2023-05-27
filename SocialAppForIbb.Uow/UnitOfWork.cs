using SocialAppForIbb.Dal;
using SocialAppForIbb.Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppForIbb.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public IFollowRepository Follows { get; }
        public IPostRepository Posts { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(Context context)
        {
            _context = context;
            Follows = new FollowRepository(context);
            Posts = new PostRepository(context);
            Users = new UserRepository(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
