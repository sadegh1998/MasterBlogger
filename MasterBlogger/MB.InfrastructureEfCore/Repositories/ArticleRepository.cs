using MB.ApplicationContract.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.InfrastructureEfCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }
        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(c => c.ArticleCategory).Select(x=> new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(),
                IsDeleted = x.IsDeleted ,
                ArticleCategory = x.ArticleCategory.Title
            }).ToList();
        }
    }
}
