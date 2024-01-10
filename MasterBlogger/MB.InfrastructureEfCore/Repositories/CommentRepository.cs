using _01_Framework.InfrastructureEf;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MB.InfrastructureEfCore.Repositories
{
    public class CommentRepository : BaseRepository<long,Comment>,ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context) : base(context) 
        {
            _context = context;
        }

        public List<Comment> GetComments()
        {
            return _context.Comments.Include(x=>x.Article).ToList();
        }

    }
}
