using MB.ApplicationContract;
using MB.ApplicationContract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.List();
        }
        public RedirectToPageResult OnPostActivate(int Id)
        {
            _articleCategoryApplication.Active(Id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostRemove(int Id)
        {
            _articleCategoryApplication.Remove(Id);
            return RedirectToPage("./List");

        }
    }
}
