using MB.ApplicationContract.Comment;
using MB.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(CreateComment command)
        {
            var comment = new Comment(command.Name ,command.Message,command.Email , command.ArticleId);
            _commentRepository.Create(comment);
        }

        public void Cancel(long id)
        {
            var comment = _commentRepository.Get(id);
            comment.Cancel();
        }

        public void Confirm(long id)
        {
            var comment = _commentRepository.Get(id);
            comment.Confirm();
        }

        public List<CommentViewModel> GetComments()
        {
            return _commentRepository.GetComments();
        }
    }
}
