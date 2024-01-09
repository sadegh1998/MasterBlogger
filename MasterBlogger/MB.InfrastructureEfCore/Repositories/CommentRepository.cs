using MB.ApplicationContract.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.InfrastructureEfCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        

        public void Create(Comment comment)
        {
            _context.Comments.Add(comment);
            Save();
        }

        public Comment Get(long id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public List<CommentViewModel> GetComments()
        {
            return _context.Comments.Include(x=>x.Article).Select(x=>new CommentViewModel { 
            Id = x.Id ,
            Email = x.Email ,
            Message = x.Message ,
            Name = x.Name ,
            Status = x.Status,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture) ,
            Article = x.Article.Title
            }).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
