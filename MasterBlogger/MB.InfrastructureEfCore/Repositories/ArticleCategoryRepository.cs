using MB.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.InfrastructureEfCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Create(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            Save();
        }

        public bool Exsists(string title)
        {
            return _context.ArticleCategories.Any(x => x.Title == title);
        }

        public ArticleCategory Get(int id)
        {
            return _context.ArticleCategories.FirstOrDefault(c=>c.Id == id);
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.OrderByDescending(c=>c.Id).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
