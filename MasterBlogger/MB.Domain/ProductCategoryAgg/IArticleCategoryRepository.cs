using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ProductCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        void Create(ArticleCategory entity);
        List<ArticleCategory> GetAll();
    }
}
