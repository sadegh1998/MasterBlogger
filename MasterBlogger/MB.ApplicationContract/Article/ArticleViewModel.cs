using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.ApplicationContract.Article
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ArticleCategory { get; set; }
        public bool IsDeleted { get; set; }
        public string CreationDate { get; set; }
    }
}

