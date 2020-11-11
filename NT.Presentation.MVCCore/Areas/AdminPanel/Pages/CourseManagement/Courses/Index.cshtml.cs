using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.CM.Application.Contracts;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.Courses
{
    public class IndexModel : PageModel
    {
        public ICourseApplication _icourseapplication;
        public List<CourseViewModel> courseVM { get; set; }
        public CourseViewModel SearchModel { get; set; }
        public IndexModel(ICourseApplication icoursepplication)
        {
            _icourseapplication = icoursepplication;
        }

        public void OnGet(CourseViewModel searchmodel)
        {
            courseVM = _icourseapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CourseViewModel());
        }
        public JsonResult OnPostCreate(CourseViewModel coursevm)
        {
            var result = _icourseapplication.Create(coursevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _icourseapplication.GetBy(id);
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(CourseViewModel coursevm)
        {
            var result = _icourseapplication.Edit(coursevm);
            return new JsonResult(result);
        }
        public JsonResult OnPostRemove(CourseViewModel coursevm)
        {
            var result = _icourseapplication.Remove(coursevm.ID);
            return new JsonResult(result);
        }
    }
}
