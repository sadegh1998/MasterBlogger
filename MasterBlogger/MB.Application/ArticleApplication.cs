﻿using MB.ApplicationContract.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
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

        public ArticleApplication(IArticleRepository articleRepository,IArticleValidatorService articleValidatorService)
        {
            _articleRepository = articleRepository;
            _articleValidatorService = articleValidatorService; 
        }

        public void Active(long id)
        {
            var article =_articleRepository.Get(id);
            article.Activate();
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ShortDescription,command.Image, command.Content, command.ArticleCategoryId,_articleValidatorService);
            _articleRepository.Create(article);
        }

        public void Delete(long id)
        {
            var article = _articleRepository.Get(id);
            article.Remove();
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCategoryId);
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
           return _articleRepository.GetList();
        }
    }
}
