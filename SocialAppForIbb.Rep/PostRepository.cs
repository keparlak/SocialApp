using Microsoft.EntityFrameworkCore;
using SocialAppForIbb.Core.Concrete;
using SocialAppForIbb.Dal;
using SocialAppForIbb.Ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppForIbb.Rep
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(Context context) : base(context)
        {
        }

        public async Task<List<Post>> GetPostsByUserIdAsync(int userId)
        {
            return await _context.Set<Post>()
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<DateTime> GetLatestPostTimeAsync(int userId)
        {
            return await _context.Set<Post>()
                .Where(p => p.UserId == userId)
                .MaxAsync(p => p.CreatedAt);
        }
    }
}
