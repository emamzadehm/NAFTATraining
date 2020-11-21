using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.CM.Application.Contracts;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.Courses;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseApplication _icourseapplication;
        private readonly IBaseInfoApplication _ibaseinfoapplication;
        public List<CourseViewModel> courseVM { get; set; }
        public CourseViewModel SearchModel { get; set; }

        public IndexModel(ICourseApplication icourseapplication, IBaseInfoApplication ibaseinfoapplication)
        {
            _icourseapplication = icourseapplication;
            _ibaseinfoapplication = ibaseinfoapplication;
        }

        public void OnGet(CourseViewModel searchmodel)
        {
            courseVM = _icourseapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CourseViewModel
            {
                Level = _ibaseinfoapplication.Search(),
                Category = _ibaseinfoapplication.Search()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CourseViewModel coursevm)
        {
            var result = _icourseapplication.Create(coursevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _icourseapplication.GetBy(id);
            selecteditem.Category = _ibaseinfoapplication.Search();
            selecteditem.Level = _ibaseinfoapplication.Search();
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(CourseViewModel coursevm)
        {
            var result = _icourseapplication.Edit(coursevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(CourseViewModel coursevm)
        {
            _icourseapplication.Remove(coursevm.ID);
            return RedirectToPage("Index");
        }
    }
}
