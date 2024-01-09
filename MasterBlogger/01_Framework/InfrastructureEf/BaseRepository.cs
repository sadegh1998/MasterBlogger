using _01_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.InfrastructureEf
{
    public class BaseRepository<Tkey, T> : IRepository<Tkey, T> where T : DomainBase<Tkey>
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public bool Exsits(Expression<Func<T, bool>> expression)
        {
           return _context.Set<T>().Any(expression);
        }

        public T Get(Tkey Id)
        {
            return _context.Find<T>(Id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
