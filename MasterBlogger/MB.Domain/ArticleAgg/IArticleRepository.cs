using MB.ApplicationContract.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void Add(Article command);
        Article Get(long Id);
        void Delete(long Id);   
        void Active(long Id);
        void Save();
    }
}
