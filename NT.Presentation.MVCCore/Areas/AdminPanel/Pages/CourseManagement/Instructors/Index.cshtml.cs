using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.Instructors;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly IInstructorApplication _iinstructorapplication;
        private readonly IUserApplication _iuserApplication;

        public List<InstructorsViewModel> instructorVM { get; set; }
        public InstructorsViewModel SearchModel { get; set; }

        public IndexModel(IInstructorApplication iinstructorapplication, IUserApplication iuserApplication)
        {
            _iinstructorapplication = iinstructorapplication;
            _iuserApplication = iuserApplication;
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
            var selecteditem = _iinstructorapplication.GetDetails(id);
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
        public IActionResult OnGetView(long id)
        {
            var selecteditem = _iinstructorapplication.GetDetails(id);

            return Partial("./View", selecteditem);
        }
        public IActionResult OnGetChangePassword(long id)
        {
            var selecteditem = _iinstructorapplication.GetDetails(id);
            var selectedUser = _iuserApplication.GetDetails(selecteditem.UserID);
            return Partial("./ChangePassword", selectedUser);

        }
        public JsonResult OnPostChangePassword(UsersViewModel usersvm)
        {
            var result = _iuserApplication.ChangePassword(usersvm.ID, usersvm.Password);
            return new JsonResult(result);
        }

    }
}
