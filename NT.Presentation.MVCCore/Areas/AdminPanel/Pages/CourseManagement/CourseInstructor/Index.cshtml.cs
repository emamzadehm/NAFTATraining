using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NT.CM.Application.Contracts;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;
using NT.CM.Application.Contracts.ViewModels.Courses;
using NT.CM.Application.Contracts.ViewModels.Instructors;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.CourseInstructor
{
    public class IndexModel : PageModel
    {
        private readonly IInstructorApplication _iinstructorapplication;
        private readonly ICourseApplication _icourseapplication;
        private readonly ICourseInstructorApplication _icourseinstructorapplication;
        private readonly IBaseInfoApplication _ibaseinfoapplication;

        public List<CourseInstructorViewModel> courseinstructorVM { get; set; }
        public CourseInstructorViewModel SearchModel { get; set; }
        public InstructorsViewModel searchmodelinstructor;
        public CourseViewModel searchmodelcourse;

        public SelectList instructorlist;
        public SelectList courselist;
        public SelectList locationlist;

        public IndexModel(IInstructorApplication iinstructorapplication, ICourseApplication icourseapplication,
            ICourseInstructorApplication icourseinstructorapplication, IBaseInfoApplication ibaseinfoapplication)
        {
            _iinstructorapplication = iinstructorapplication;
            _icourseapplication = icourseapplication;
            _icourseinstructorapplication = icourseinstructorapplication;
            _ibaseinfoapplication = ibaseinfoapplication;
        }

        public void OnGet(CourseInstructorViewModel searchmodel)
        {
            searchmodelinstructor = new InstructorsViewModel();
            searchmodelcourse = new CourseViewModel();
            instructorlist = new SelectList(_iinstructorapplication.Search(searchmodelinstructor), "ID", "ID");
            courselist = new SelectList(_icourseapplication.Search(searchmodelcourse), "ID", "CName");
            locationlist = new SelectList(_ibaseinfoapplication.GetAll(), "ID", "Title");
            courseinstructorVM = _icourseinstructorapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            searchmodelinstructor = new InstructorsViewModel();
            searchmodelcourse = new CourseViewModel();
            var command = new CourseInstructorViewModel
            {
                InstructorList = _iinstructorapplication.Search(searchmodelinstructor),
                CourseList = _icourseapplication.Search(searchmodelcourse),
                LocationList = _ibaseinfoapplication.GetAll()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CourseInstructorViewModel courseinstructorvm)
        {
            var result = _icourseinstructorapplication.Create(courseinstructorvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _icourseinstructorapplication.GetDetails(id);
            searchmodelinstructor = new InstructorsViewModel();
            searchmodelcourse = new CourseViewModel();
            selecteditem.LocationList = _ibaseinfoapplication.GetAll();
            selecteditem.CourseList = _icourseapplication.Search(searchmodelcourse);
            selecteditem.InstructorList = _iinstructorapplication.Search(searchmodelinstructor);
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(CourseInstructorViewModel courseinstructorvm)
        {
            var result = _icourseinstructorapplication.Edit(courseinstructorvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(CourseInstructorViewModel courseinstructorvm)
        {
            _icourseinstructorapplication.Remove(courseinstructorvm.ID);
            return RedirectToPage("Index");
        }
    }
}
