using MB.ApplicationContract.Comment;
using MB.Domain.CommentAgg;
using MB.InfrastructureEfCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(CreateComment command)
        {
            _unitOfWork.BeginTran();
            var comment = new Comment(command.Name ,command.Message,command.Email , command.ArticleId);
            _commentRepository.Create(comment);
            _unitOfWork.CommitTran();
        }

        public void Cancel(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _commentRepository.Get(id);
            comment.Cancel();
            _unitOfWork.CommitTran();
        }

        public void Confirm(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _commentRepository.Get(id);
            comment.Confirm();
            _unitOfWork.CommitTran();
        }

        public List<CommentViewModel> GetComments()
        {
            var comments =  _commentRepository.GetComments();
            return comments.Select(x => new CommentViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Message = x.Message,
                Name = x.Name,
                Status = x.Status,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Article = x.Article.Title
            }).ToList();
        }
    }
}
