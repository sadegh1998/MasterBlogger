using MB.ApplicationContract;
using MB.ApplicationContract.Article;
using MB.ApplicationContract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {
        public List<SelectListItem> ArticleCategorySelectedList { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _articleApplication;
        public CreateModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            ArticleCategorySelectedList = _articleCategoryApplication.List()
                .Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
        }
        public RedirectToPageResult OnPost(CreateArticle command)
        {
            _articleApplication.Create(command);
            return RedirectToPage("./List");
        }
    }
}
