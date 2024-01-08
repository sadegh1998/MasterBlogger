using MB.ApplicationContract.Article;
using MB.Domain.ArticleAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _articleApplication;

        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetAll();
        }
        public RedirectToPageResult OnPostActivate(long id) 
        {
            _articleApplication.Active(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleApplication.Delete(id);
            return RedirectToPage("./List");
        }
    }
}
