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
    public class FollowRepository : BaseRepository<Follow>, IFollowRepository
    {
        public FollowRepository(Context context) : base(context)
        {
        }

        public async Task<List<Follow>> GetFollowersAsync(int userId)
        {
            return await _context.Set<Follow>()
                .Where(f => f.FollowedUserId == userId)
                .ToListAsync();
        }

        public async Task<List<Follow>> GetFollowingsAsync(int userId)
        {
            return await _context.Set<Follow>()
                .Where(f => f.FollowingUserId == userId)
                .ToListAsync();
        }

        public async Task<DateTime> GetLatestFollowedTimeAsync(int userId)
        {
            return await _context.Set<Follow>()
                .Where(f => f.FollowedUserId == userId)
                .MaxAsync(f => f.CreatedAt);
        }
    }
}
