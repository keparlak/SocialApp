using SocialAppForIbb.Core.Abstract;
using SocialAppForIbb.Ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppForIbb.Rep
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<List<Post>> GetPostsByUserIdAsync(int userId);
        Task<DateTime> GetLatestPostTimeAsync(int userId);
    }
}
