using _01_Framework.InfrastructureEf;
using MB.ApplicationContract.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long , Comment>
    {
        List<CommentViewModel> GetComments();
    }
}
