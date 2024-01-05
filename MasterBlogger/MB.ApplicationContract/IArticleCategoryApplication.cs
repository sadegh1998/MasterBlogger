using MB.ApplicationContract.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.ApplicationContract
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Create(CreateArticleCategoryViewModel command);
        void Rename(RenameArticleCategory command);
        RenameArticleCategory Get(int id);
        void Remove(int id);
        void Active(int id);
    }
}
