using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NT.CM.Application.Contracts;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.Candidates
{
    public class EditModel : PageModel
    {
        //[BindProperty]public CourseCandidateViewModel CourseCandidateViewModel { get; set; }
        public List<SelectListItem> Courseviewmodel { get; set; }
        private readonly ICandidateCourseInstructorApplication _icoursecandidateapplication;
        private readonly ICourseApplication _icoursepplication;

        public EditModel(ICandidateCourseInstructorApplication icoursecandidateapplication, ICourseApplication icoursepplication)
        {
            _icoursecandidateapplication = icoursecandidateapplication;
            _icoursepplication = icoursepplication;;
        }

        //public void OnGet(CourseCandidateViewModel courseCandidateViewModel)
        public void OnGet()
        {
  //          Courseviewmodel = _icoursepplication.List().Select(x=>new SelectListItem(x.CName,x.ID.ToString())).ToList();
//            CourseCandidateViewModel = _icoursecandidateapplication.GetBy(courseCandidateViewModel.Id);
        }

        public RedirectToPageResult OnPost()
        {
    //        _icoursecandidateapplication.Edit(CourseCandidateViewModel);
            return RedirectToPage("List");
        }
    }
}
