using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ProductCategoryAgg.Exceptions
{
    public class DuplicatedRecordException : Exception
    {
        public DuplicatedRecordException()
        {
                
        }
        public DuplicatedRecordException(string message) : base(message) 
        {
            
        }
    }
}
