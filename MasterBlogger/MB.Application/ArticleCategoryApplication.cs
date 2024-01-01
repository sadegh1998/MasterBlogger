using MB.ApplicationContract;
using MB.ApplicationContract.ArticleCategory;
using MB.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    internal class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var item in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel { 
                Id = item.Id,
                Title = item.Title,
                CreationDate = item.CreationDate.ToString() , 
                IsDeleted = item.IsDeleted
                });
            }
            return result;

        }
    }
}
