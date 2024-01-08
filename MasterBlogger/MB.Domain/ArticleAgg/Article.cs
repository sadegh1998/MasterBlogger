using MB.Domain.ArticleAgg.Services;
using MB.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsDeleted { get; private set; }
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }
        protected Article()
        {
                
        }

        public Article(string title, string shortDescription, string image, string content, long articleCategoryId,IArticleValidatorService validatorService)
        {
            Validate(title, articleCategoryId);
            validatorService.CheckThatThisRecordAlreadyExsit(title);

            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }
        public void Edit(string title, string shortDescription, string image, string content, long articleCategoryId, IArticleValidatorService validatorService)
        {
            Validate(title, articleCategoryId);
            validatorService.CheckThatThisRecordAlreadyExsit(title);

            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
        }
        public void Remove()
        {
            IsDeleted = true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }
        public static void Validate(string title , long articleCategoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException();
            }

            if(articleCategoryId == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
