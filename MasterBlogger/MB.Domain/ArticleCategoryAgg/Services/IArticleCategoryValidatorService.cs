using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ProductCategoryAgg.Services
{
    public interface IArticleCategoryValidatorService
    {
        void CheckThatThisRecordAlreadyExsit(string title);
    }
}
