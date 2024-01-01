using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ProductCategoryAgg
{
    public class ProductCategory
    {
        public int Id { get; private set; }
        public string Title { get;private set; }
        public DateTime CreationDate { get;private set; }
        public bool IsDeleted { get;private set; }

        public ProductCategory(string title)
        {
            Title = title;
            CreationDate = DateTime.Now;
            IsDeleted = false;
        }
    }
    
}
