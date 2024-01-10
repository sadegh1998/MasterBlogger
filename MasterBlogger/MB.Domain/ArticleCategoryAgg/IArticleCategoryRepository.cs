using _01_Framework.InfrastructureEf;

namespace MB.Domain.ProductCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long , ArticleCategory>
    {
    }
}
