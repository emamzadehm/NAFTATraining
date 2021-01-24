using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.UsersManagement.Roles
{
    public class IndexModel : PageModel
    {
        public IRolesApplication _irolesApplication;
        public List<RolesViewModel> roleVM { get; set; }
        public RolesViewModel SearchModel { get; set; }

        public IndexModel(IRolesApplication irolesApplication)
        {
            _irolesApplication = irolesApplication;
        }

        public void OnGet(RolesViewModel searchmodel)
        {
            roleVM = _irolesApplication.Search(searchmodel);
        }
        public IActionResult OnGetRemove(RolesViewModel rolevm)
        {
            _irolesApplication.Remove(rolevm.ID);
            return RedirectToPage("Index");
        }
    }
}
