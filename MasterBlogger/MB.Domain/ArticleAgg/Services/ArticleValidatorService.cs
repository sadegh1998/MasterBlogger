using MB.ApplicationContract.Article;
using MB.Domain.ProductCategoryAgg.Exceptions;
using System;

namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleValidatorService : IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidatorService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void CheckThatThisRecordAlreadyExsit(string title)
        {
            if (_articleRepository.Exsits(title))
            {
                throw new DuplicatedRecordException("The record already exsits in database");
            }
        }
    }
}
