using SocialAppForIbb.Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppForIbb.Uow
{
    public interface IUnitOfWork
    {
        IFollowRepository Follows { get; }
        IPostRepository Posts { get; }
        IUserRepository Users { get; }

        Task<int> SaveChangesAsync();
    }
}
