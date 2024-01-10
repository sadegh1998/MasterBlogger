using MB.ApplicationContract.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.InfrastructureEfCore;
using Microsoft.EntityFrameworkCore;
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
        private readonly IArticleValidatorService _articleValidatorService;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleApplication(IArticleRepository articleRepository,IArticleValidatorService articleValidatorService, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _articleValidatorService = articleValidatorService;
            _unitOfWork = unitOfWork;
        }

        public void Active(long id)
        {
            _unitOfWork.BeginTran();
            var article =_articleRepository.Get(id);
            article.Activate();
            _unitOfWork.CommitTran();
        }

        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();
            var article = new Article(command.Title, command.ShortDescription,command.Image, command.Content, command.ArticleCategoryId,_articleValidatorService);
            _articleRepository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Delete(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Remove();
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCategoryId);
            _unitOfWork.CommitTran();
        }

        public EditArticle Get(long id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle
            {
                 Id = article.Id,Title = article.Title,ShortDescription = article.ShortDescription,Content=article.Content,Image=article.Image,ArticleCategoryId=article.ArticleCategoryId
            };
        }

        public List<ArticleViewModel> GetAll()
        {
           var article =  _articleRepository.GetList();
            return article.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(),
                IsDeleted = x.IsDeleted,
                ArticleCategory = x.ArticleCategory.Title
            }).ToList();
        }
    }
}
