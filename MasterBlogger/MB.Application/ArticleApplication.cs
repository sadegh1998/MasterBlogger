using MB.ApplicationContract.Article;
using MB.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ShortDescription,command.Image, command.Content, command.ArticleCategoryId);
            _articleRepository.Add(article);
        }

        public List<ArticleViewModel> GetAll()
        {
           return _articleRepository.GetList();
        }
    }
}
