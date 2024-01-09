using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.InfrastructureEfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MasterBloggerContext _context;

        public UnitOfWork(MasterBloggerContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollBackTran()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
