using _01_Framework.InfrastructureEf;
using MB.ApplicationContract.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long,Article>
    {
        List<ArticleViewModel> GetList();
    }
}
