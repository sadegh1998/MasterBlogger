using MB.ApplicationContract;
using MB.ApplicationContract.ArticleCategory;
using MB.Domain.ProductCategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public RenameArticleCategory ArticleCategory { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(int id)
        {
            ArticleCategory = _articleCategoryApplication.Get(id);
        }
        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Rename(ArticleCategory);
            return RedirectToPage("./List");
        }
    }
}
