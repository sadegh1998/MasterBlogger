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
        void Edit(EditArticle command);
        EditArticle Get(long id);  
        void Delete(long id);
        void Active(long id);
    }
}
