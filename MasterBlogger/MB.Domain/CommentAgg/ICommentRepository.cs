using _01_Framework.InfrastructureEf;
using System.Collections.Generic;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long , Comment>
    {
        List<Comment> GetComments();
    }
}
