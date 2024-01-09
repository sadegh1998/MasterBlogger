using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.InfrastructureEfCore
{
    public interface IUnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void RollBackTran();
    }
}
