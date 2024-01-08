using MB.ApplicationContract;
using MB.ApplicationContract.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditArticle EditArticle { get; set; }
        public List<SelectListItem> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _categoryApplication;
        private readonly IArticleApplication _articleApplication;

        public EditModel(IArticleCategoryApplication categoryApplication, IArticleApplication articleApplication)
        {
            _categoryApplication = categoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet(long id)
        {
            EditArticle = _articleApplication.Get(id);
            ArticleCategories = _categoryApplication.List().Select(x=> new SelectListItem { 
            Value = x.Id.ToString(),
            Text = x.Title
            }).ToList();
        }
        public RedirectToPageResult OnPost()
        {
            _articleApplication.Edit(EditArticle);
            return RedirectToPage("./List");
        }
    }
}
