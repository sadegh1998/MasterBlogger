using _01_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.InfrastructureEf
{
    public interface IRepository<Tkey , T> where T : DomainBase<Tkey>
    {
        void Create(T entity);
        T Get(Tkey Id);
        List<T> GetAll();
        bool Exsits(Expression<Func<T, bool>> expression);
    }
}
