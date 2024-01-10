using _01_Framework.InfrastructureEf;
using System.Collections.Generic;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long,Article>
    {
        List<Article> GetList();
    }
}
