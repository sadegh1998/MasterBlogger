using _01_Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ProductCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ProductCategoryAgg
{
    public class ArticleCategory : DomainBase<long>
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<Article> Articles { get; private set; }
        protected ArticleCategory() { }
        public ArticleCategory(string title,IArticleCategoryValidatorService validator)
        {
            GuardAgainstEmptyTitle(title);
            validator.CheckThatThisRecordAlreadyExsit(title);

            Title = title;
            IsDeleted = false;
            Articles = new List<Article>();
        }
        public void Rename(string title, IArticleCategoryValidatorService validator)
        {
            GuardAgainstEmptyTitle(title);
            validator.CheckThatThisRecordAlreadyExsit(title);
            Title = title;
        }
        public void Remove()
        {
            IsDeleted = true;
        }
        public void Activated()
        {
            IsDeleted = false;
        }
        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }
    }

}
