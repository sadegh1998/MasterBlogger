using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.ApplicationContract.Comment
{
    public interface ICommentApplication
    {
        void Add(CreateComment command);
        void Confirm(long id);
        void Cancel(long id);
        List<CommentViewModel> GetComments();
    }
}
