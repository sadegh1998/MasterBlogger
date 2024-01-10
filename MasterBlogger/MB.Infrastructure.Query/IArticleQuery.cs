using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.Query
{
    public interface IArticleQuery
    {
         Task<List<ArticleQueryView>> GetAllArticle();
        Task<ArticleQueryView> GetArticle(long id);
    }
}
