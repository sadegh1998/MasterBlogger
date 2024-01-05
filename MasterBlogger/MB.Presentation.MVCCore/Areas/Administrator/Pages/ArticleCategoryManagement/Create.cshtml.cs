using MB.ApplicationContract;
using MB.ApplicationContract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class CreateModel : PageModel
    {
      private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(CreateArticleCategoryViewModel command)  
        {
            _articleCategoryApplication.Create(command);
            return RedirectToPage("./List");
        }
    }
}
