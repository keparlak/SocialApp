using Microsoft.EntityFrameworkCore;
using SocialAppForIbb.Core.Abstract;
using SocialAppForIbb.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppForIbb.Core.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly Context context;

        public BaseRepository(Context context)
        {
            this.context = context;
        }

        public bool Add(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> List()
        {
            throw new NotImplementedException();
        }

        public DbSet<T> Set()
        {
            return context.Set<T>();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
