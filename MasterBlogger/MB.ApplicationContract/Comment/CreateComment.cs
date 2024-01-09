using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.ApplicationContract.Comment
{
    public class CreateComment
    {
        public string Name { get;  set; }
        public string Message { get;  set; }
        public string Email { get;  set; }
        public long ArticleId { get; set; }
    }
}
