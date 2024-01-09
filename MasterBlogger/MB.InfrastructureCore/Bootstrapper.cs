using MB.ApplicationContract;
using Microsoft.Extensions.DependencyInjection;
using MB.Domain.ProductCategoryAgg;
using MB.Application;
using MB.InfrastructureEfCore.Repositories;
using MB.InfrastructureEfCore;
using Microsoft.EntityFrameworkCore;
using MB.ApplicationContract.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ProductCategoryAgg.Services;
using MB.Domain.ArticleAgg.Services;
using MB.Infrastructure.Query;
using MB.Domain.CommentAgg;
using MB.ApplicationContract.Comment;

namespace MB.InfrastructureCore
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services , string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
            services.AddTransient<IArticleValidatorService, ArticleValidatorService>();
            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentApplication, CommentApplication>();
            services.AddDbContext<MasterBloggerContext>(options=>options.UseSqlServer(connectionString));
        }
    }
}
