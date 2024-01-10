using _01_Framework.InfrastructureEf;
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
    public class ArticleRepository : BaseRepository<long,Article>,IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context):base(context)
        {
            _context = context;
        }   
        public List<Article> GetList()
        {
            return _context.Articles.Include(c => c.ArticleCategory).ToList();
        }

    }
}
