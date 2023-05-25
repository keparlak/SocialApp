using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppForIbb.Core.Abstract
{
    public interface IBaseRepository <T> where T : class
    {
        public List<T> List();
        public T Find(int id);
        public bool Update(T entity);
        public bool Delete(T entity);
        public bool Add(T entity);
        public DbSet<T> Set();
    }
}
