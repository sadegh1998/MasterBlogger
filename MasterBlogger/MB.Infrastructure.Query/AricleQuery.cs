using MB.Domain.CommentAgg;
using MB.InfrastructureEfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetAllArticle()
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Include(x=>x.Comments)
                .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Content = x.Content,
                Image = x.Image,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                CommentsCount = x.Comments.Count(x=>x.Status == Statuses.Confirm)

            }).ToList();
        }

        public ArticleQueryView GetArticle(long id)
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.Comments)
                .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Content = x.Content,
                Image = x.Image,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                CommentsCount = x.Comments.Count(x=>x.Status == Statuses.Confirm),
                Comments = MapComment(x.Comments.Where(x => x.Status == Statuses.Confirm))

            }).FirstOrDefault(x => x.Id == id);
        }
        private static List<CommentQueryView> MapComment(IEnumerable<Comment> command) {
            return command.Select(command => new CommentQueryView { 
            Name = command.Name,
            CreationDate = command.CreationDate.ToString(CultureInfo.InvariantCulture) ,
            Message = command.Message
            }).ToList();
        }


    }
}
