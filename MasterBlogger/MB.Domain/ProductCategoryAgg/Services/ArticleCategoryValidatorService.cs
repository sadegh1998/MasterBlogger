using MB.Domain.ProductCategoryAgg.Exceptions;
using System;

namespace MB.Domain.ProductCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThatThisRecordAlreadyExsit(string title)
        {
            if (_articleCategoryRepository.Exsists(title))
                throw new DuplicatedRecordException("The record already exsits in database");
        }
    }
}
