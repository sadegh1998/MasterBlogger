using _01_Framework.InfrastructureEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ProductCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long , ArticleCategory>
    {
    }
}
