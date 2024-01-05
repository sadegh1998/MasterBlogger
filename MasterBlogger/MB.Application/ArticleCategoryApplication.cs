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
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void Active(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activated();
            _articleCategoryRepository.Save();
            
        }

        public void Create(CreateArticleCategoryViewModel command)
        {
            var articleCategory = new ArticleCategory(command.Title);
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
            var result = new List<ArticleCategoryViewModel>();
            foreach (var item in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    CreationDate = item.CreationDate.ToString(),
                    IsDeleted = item.IsDeleted
                });
            }
            return result;

        }

        public void Remove(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _articleCategoryRepository.Save();

        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
            _articleCategoryRepository.Save();
        }
    }
}
