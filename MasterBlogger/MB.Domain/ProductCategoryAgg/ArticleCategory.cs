using MB.Domain.ProductCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ProductCategoryAgg
{
    public class ArticleCategory
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsDeleted { get; private set; }

        public ArticleCategory(string title,IArticleCategoryValidatorService validator)
        {
            GuardAgainstEmptyTitle(title);
            validator.CheckThatThisRecordAlreadyExsit(title);

            Title = title;
            CreationDate = DateTime.Now;
            IsDeleted = false;
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
