using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.InfrastructureEfCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(c=>c.Id);

            builder.Property(c=>c.Name);
            builder.Property(c => c.Email);
            builder.Property(c => c.Message);
            builder.Property(c => c.Status);
            builder.Property(c => c.CreationDate);

            builder.HasOne(x => x.Article).WithMany(x => x.Comments).HasForeignKey(x=>x.ArticleId);

        }
    }
}
