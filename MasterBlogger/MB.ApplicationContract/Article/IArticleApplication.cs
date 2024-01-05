using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.ApplicationContract.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetAll();
        void Create(CreateArticle command);
        
    }
}
