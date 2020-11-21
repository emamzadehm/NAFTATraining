using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NT.CM.Application.Contracts;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor;
using NT.CM.Application.Contracts.ViewModels.Candidates;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;


namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.CandidateCourseInstructor
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateCourseInstructorApplication _icandidatecourseinstructorapplication;
        private readonly ICourseInstructorApplication _icourseinstructorapplication;
        private readonly ICandidateApplication _icandidateapplication;
        private readonly ICourseApplication _icourseapplication;
        private readonly ICompanyApplication _icompanyapplication;
        private readonly IInstructorApplication _iinstructorapplication;

        public IndexModel(ICandidateCourseInstructorApplication icandidatecourseinstructorapplication,
            ICourseInstructorApplication icourseinstructorapplication, ICandidateApplication icandidateapplication,
            ICourseApplication icourseapplication, ICompanyApplication icompanyapplication,
            IInstructorApplication iinstructorapplication)
        {
            _icandidatecourseinstructorapplication = icandidatecourseinstructorapplication;
            _icourseinstructorapplication = icourseinstructorapplication;
            _icandidateapplication = icandidateapplication;
            _icourseapplication = icourseapplication;
            _icompanyapplication = icompanyapplication;
            _iinstructorapplication = iinstructorapplication;
        }

        public List<CandidateCourseInstructorViewModel> candidatecourseinstructorVM { get; set; }
        public CandidateCourseInstructorViewModel SearchModel { get; set; }
        public CourseInstructorViewModel searchmodelcourseinstructor;
        public CandidateViewModel searchmodelcandidate;


        public SelectList courselist;
        public SelectList instructorlist;
        public SelectList candidatelist;
        public SelectList companylist;



        public void OnGet(CandidateCourseInstructorViewModel searchmodel)
        {
            searchmodelcourseinstructor = new CourseInstructorViewModel();

            courselist = new SelectList(_icourseapplication.Search(), "CourseID", "CourseName");
            instructorlist = new SelectList(_iinstructorapplication.Search(), "InstructorID", "InstructorName");
            companylist = new SelectList(_icompanyapplication.Search(), "CompanyID", "CompanyName");

            candidatecourseinstructorVM = _icandidatecourseinstructorapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateEditCandidateCourseInstructorViewModel
            {
                CourseInstructorList = _icourseinstructorapplication.Search(),
                CandidateList = _icandidateapplication.Search()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateEditCandidateCourseInstructorViewModel candidatecourseinstructorvm)
        {
            var result = _icandidatecourseinstructorapplication.Create(candidatecourseinstructorvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _icandidatecourseinstructorapplication.GetDetails(id);
            selecteditem.CourseInstructorList = _icourseinstructorapplication.Search();
            selecteditem.CandidateList = _icandidateapplication.Search();
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(CreateEditCandidateCourseInstructorViewModel candidatecourseinstructorvm)
        {
            var result = _icandidatecourseinstructorapplication.Edit(candidatecourseinstructorvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(CandidateCourseInstructorViewModel candidatecourseinstructorvm)
        {
            _icandidatecourseinstructorapplication.Remove(candidatecourseinstructorvm.ID);
            return RedirectToPage("Index");
        }
    }
}
