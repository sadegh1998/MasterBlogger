using MB.ApplicationContract.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void Add(Article command);
        void Save();
    }
}
