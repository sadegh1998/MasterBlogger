using MB.ApplicationContract.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Create(Comment comment);
        List<CommentViewModel> GetComments();
        Comment Get(long id);
        void Save();
    }
}
