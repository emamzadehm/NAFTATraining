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
        public IPermissionTypes _ipermissionTypes;
        //public List<PermissionTypes> permissiontypes;


        public IndexModel(IPermissionsApplication ipermissionsApplication, IPermissionTypes ipermissionTypes)
        {
            _ipermissionsApplication = ipermissionsApplication;
            _ipermissionTypes = ipermissionTypes;
        }

        public void OnGet(PermissionsViewModel searchmodel)
        {
            permissionsVM = _ipermissionsApplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new PermissionsViewModel
            {
                PermissionTypesList = _ipermissionTypes.Expose(),
                ParentList = _ipermissionsApplication.Search()
            };
            return Partial("./Create", command);
            //return FillPermissionOperation(3);
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
        public JsonResult OnGetFillPermissionOperation(long id)
        {
            var parentslist = _ipermissionsApplication.GetPermissionOperationByType(id);
            var parentlist =  new JsonResult(parentslist);
            return parentlist;
        }

    }
}
