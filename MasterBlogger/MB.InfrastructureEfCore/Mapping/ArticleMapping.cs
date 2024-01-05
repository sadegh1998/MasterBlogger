using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.InfrastructureEfCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(t => t.Id);  
            builder.Property(t=>t.Title).IsRequired();
            builder.Property(t => t.Content).IsRequired();
            builder.Property(t => t.Image);
            builder.Property(t => t.ShortDescription);
            builder.Property(t => t.CreationDate);
            builder.Property(t => t.IsDeleted);


            builder.HasOne(x => x.ArticleCategory).WithMany(x=>x.Articles).HasForeignKey(x=>x.ArticleCategoryId);

        }
    }
}
