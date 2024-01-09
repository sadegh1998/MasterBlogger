using MB.ApplicationContract;
using MB.ApplicationContract.ArticleCategory;
using MB.Domain.ProductCategoryAgg;
using MB.Domain.ProductCategoryAgg.Services;
using MB.InfrastructureEfCore;
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
        private readonly IUnitOfWork _unitOfWork;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository,IArticleCategoryValidatorService articleCategoryValidatorService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
            _unitOfWork = unitOfWork;
        }

        public void Active(int id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activated();
            _unitOfWork.CommitTran();
        }

        public void Create(CreateArticleCategoryViewModel command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
            _articleCategoryRepository.Create(articleCategory);
            _unitOfWork.CommitTran();
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
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _unitOfWork.CommitTran();
        }

        public void Rename(RenameArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title, _articleCategoryValidatorService);
            _unitOfWork.CommitTran();   
        }
    }
}
