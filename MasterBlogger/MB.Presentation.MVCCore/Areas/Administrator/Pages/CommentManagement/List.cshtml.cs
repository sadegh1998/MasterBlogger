using MB.ApplicationContract.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }
        private readonly ICommentApplication _commentApplication;

        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.GetComments();
        }
        public RedirectToPageResult OnPostConfirm(long Id)
        {
            _commentApplication.Confirm(Id);
            return RedirectToPage("./List");

        }
        public RedirectToPageResult OnPostCancel(long Id)
        {
            _commentApplication.Cancel(Id);
            return RedirectToPage("./List");
        }
    }
}
