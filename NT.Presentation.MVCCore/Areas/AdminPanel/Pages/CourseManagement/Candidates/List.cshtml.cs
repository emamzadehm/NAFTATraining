using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.CM.Application.Contracts;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.Candidates
{
    public class ListModel : PageModel
    {
        //public List<CourseCandidateViewModel> CourseCandidateList { get; set; }
        private readonly ICandidateCourseInstructorApplication _coursecandidateapplication;
        public ListModel(ICandidateCourseInstructorApplication coursecandidateapplication)
        {
            _coursecandidateapplication = coursecandidateapplication;
        }
        public void OnGet()
        {
            //CourseCandidateList = _coursecandidateapplication.GetList();
        }
        //public RedirectToPageResult OnPostRemove(CourseCandidateViewModel DeleteItem)
        //{
        //    //_coursecandidateapplication.Delete(DeleteItem);
        //    return RedirectToPage("./List");
        //}

    }
}
