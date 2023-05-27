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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Set<User>()
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<List<User>> GetTopUsersByFollowersAsync(int count)
        {
            return await _context.Set<User>()
                .OrderByDescending(u => u.Followers.Count)
                .Take(count)
                .ToListAsync();
        }
    }
}
