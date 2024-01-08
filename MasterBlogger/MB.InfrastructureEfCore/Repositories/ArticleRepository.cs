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

        public void Active(long Id)
        {
            var article = _context.Articles.FirstOrDefault(x => x.Id == Id);
            article.Activate();
            Save();
        }

        public void Add(Article command)
        {
            _context.Add(command);
            Save();
        }

        public void Delete(long Id)
        {
            var article = _context.Articles.FirstOrDefault(x => x.Id == Id);
            article.Remove();
            Save();
        }

        public bool Exsits(string title)
        {
           return _context.Articles.Any(x => x.Title == title);
        }

        public Article Get(long Id)
        {
            return _context.Articles.FirstOrDefault(c=>c.Id == Id);
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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
