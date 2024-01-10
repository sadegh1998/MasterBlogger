using MB.ApplicationContract.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }

        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;

        

        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public async Task OnGetAsync(long id)
        {
            Article = await _articleQuery.GetArticle(id);
        }
        public RedirectToPageResult OnPost(CreateComment command)
        {
            _commentApplication.Add(command);
            return RedirectToPage("./ArticleDetails", new { id = command.ArticleId });
        }

        
    }
}