using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.UsersManagement.Permissions
{
    public class IndexModel : PageModel
    {
        public IPermissionsApplication _ipermissionsApplication;
        public List<PermissionsViewModel> permissionsVM { get; set; }
        public PermissionsViewModel SearchModel { get; set; }

        public IndexModel(IPermissionsApplication ipermissionsApplication)
        {
            _ipermissionsApplication = ipermissionsApplication;
        }

        public void OnGet(PermissionsViewModel searchmodel)
        {
            permissionsVM = _ipermissionsApplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new PermissionsViewModel());
        }
        public JsonResult OnPostCreate(PermissionsViewModel permissionsvm)
        {
            var result = _ipermissionsApplication.Create(permissionsvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var selecteditem = _ipermissionsApplication.GetDetails(id);
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(PermissionsViewModel permissionsvm)
        {
            var result = _ipermissionsApplication.Edit(permissionsvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(PermissionsViewModel permissionsvm)
        {
            _ipermissionsApplication.Remove(permissionsvm.ID);
            return RedirectToPage("Index");
        }
    }
}
