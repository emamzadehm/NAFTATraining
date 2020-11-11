using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NT.CM.Application.Contracts;
using NT.Infrastructure.Query.Interface;

namespace NT.Presentation.MVCCore.Pages
{
    public class RegisterModel : PageModel
    {
        public List<SelectListItem> CourseList { get; set; }
        private readonly ICandidateApplication _CandidateApplication;

        private readonly ICourseQuery _coursequery;
        public RegisterModel(ICandidateApplication candidateApplication, ICourseQuery coursequery)
        {
            _coursequery = coursequery;
            _CandidateApplication = candidateApplication;
        }
        public void OnGet()
        {
            CourseList = _coursequery.CourseList().Select(x=>new SelectListItem (x.CName, x.ID.ToString())).ToList();
        }
        //public RedirectToPageResult OnPost(UsersViewModel createCourseCandidateViewModels)
        //{
        //    //createCourseCandidateViewModels.CandidateId = Guid.NewGuid();
        //    //_CandidateApplication.Create(createCourseCandidateViewModels);
        //    return RedirectToPage("./Index");
        //}
    }
}