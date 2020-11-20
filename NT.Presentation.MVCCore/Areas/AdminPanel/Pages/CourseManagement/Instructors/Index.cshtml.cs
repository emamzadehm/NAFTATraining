using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.Instructors;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly IInstructorApplication _iinstructorapplication;

        public List<InstructorsViewModel> instructorVM { get; set; }
        public InstructorsViewModel SearchModel { get; set; }

        public IndexModel(IInstructorApplication iinstructorapplication)
        {
            _iinstructorapplication = iinstructorapplication;
        }

        public void OnGet(InstructorsViewModel searchmodel)
        {
            instructorVM = _iinstructorapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new InstructorsViewModel());
        }
        public JsonResult OnPostCreate(InstructorsViewModel instructorvm)
        {
            var result = _iinstructorapplication.Create(instructorvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _iinstructorapplication.GetBy(id);
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(InstructorsViewModel instructorvm)
        {
            var result = _iinstructorapplication.Edit(instructorvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(InstructorsViewModel instructorvm)
        {
            _iinstructorapplication.Remove(instructorvm.ID);
            return RedirectToPage("Index");
        }

    }
}
