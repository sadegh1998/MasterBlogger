using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ProductCategoryAgg;
namespace MB.InfrastructureEfCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title);
            builder.Property(c => c.CreationDate);
            builder.Property(c => c.IsDeleted);

            builder.HasMany(x=>x.Articles).WithOne(x=>x.ArticleCategory).HasForeignKey(x=>x.ArticleCategoryId);
        }
    }
}
