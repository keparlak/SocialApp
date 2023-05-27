using SocialAppForIbb.Core.Abstract;
using SocialAppForIbb.Ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppForIbb.Rep
{
    public interface IFollowRepository : IBaseRepository<Follow>
    {
        Task<List<Follow>> GetFollowersAsync(int userId);
        Task<List<Follow>> GetFollowingsAsync(int userId);
        Task<DateTime> GetLatestFollowedTimeAsync(int userId);
    }
}
