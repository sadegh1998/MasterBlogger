using MB.ApplicationContract;
using Microsoft.Extensions.DependencyInjection;
using MB.Domain.ProductCategoryAgg;
using MB.Application;
using MB.InfrastructureEfCore.Repositories;
using MB.InfrastructureEfCore;
using Microsoft.EntityFrameworkCore;

namespace MB.InfrastructureCore
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services , string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddDbContext<MasterBloggerContext>(options=>options.UseSqlServer(connectionString));
        }
    }
}
