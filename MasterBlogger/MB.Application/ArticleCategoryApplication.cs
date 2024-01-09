using MB.ApplicationContract;
using MB.ApplicationContract.ArticleCategory;
using MB.Domain.ProductCategoryAgg;
using MB.Domain.ProductCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository,IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }

        public void Active(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activated();
            
        }

        public void Create(CreateArticleCategoryViewModel command)
        {
            var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
            _articleCategoryRepository.Create(articleCategory);
        }

        public RenameArticleCategory Get(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory { Title = articleCategory.Title, Id = articleCategory.Id };
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();

            return articleCategories.Select(item => new ArticleCategoryViewModel
            {
                Id = item.Id,
                Title = item.Title,
                CreationDate = item.CreationDate.ToString(),
                IsDeleted = item.IsDeleted
            }).OrderByDescending(c=>c.Id).ToList();
           

        }

        public void Remove(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();

        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title, _articleCategoryValidatorService);
        }
    }
}
