using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;
using System.Collections.Generic;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.UsersManagement.Roles
{
    public class CreateModel : PageModel
    {
        public RolesViewModel RoleVM { get; set; }
        public IRolesApplication _irolesApplication;
        public IPermissionsApplication _ipermissionsApplication;
        public IPermissionTypes _ipermissionTypes;
        public List<PermissionsViewModel> modulesList;
        //public List<PermissionsViewModel> permissionsList;
        public Dictionary<long?, List<PermissionsViewModel>> Allpermissions;
        public List<SelectListItem> Permissions;


        public CreateModel(IRolesApplication irolesApplication, IPermissionsApplication ipermissionsApplication, IPermissionTypes ipermissionTypes)
        {
            _irolesApplication = irolesApplication;
            _ipermissionsApplication = ipermissionsApplication;
            _ipermissionTypes = ipermissionTypes;
        }

        public void OnGet()
        {
            modulesList = _ipermissionsApplication.GetAllModules();
            //permissionsList = _ipermissionsApplication.GetPermissionsByModule();
            Permissions = GetPermissionsByModule(0);
        }
        public List<SelectListItem> GetPermissionsByModule(long id)
        {
            Permissions = new List<SelectListItem>();
            var AllPermissions = _ipermissionsApplication.GetPermissionsByModule(id);
            foreach (var (key, value) in AllPermissions)
            {

                var parentTitle = _ipermissionsApplication.GetDetails(key).Title;
                var group = new SelectListGroup() { Name = parentTitle };
                foreach (var per in value)
                {
                    var item = new SelectListItem()
                    {
                        Value = per.ID.ToString(),
                        Text = per.Title,
                        Group = group
                    };
                    Permissions.Add(item);
                }

            }
            return Permissions;
        }
        public IActionResult OnPost(RolesViewModel rolevm)
        {
            _irolesApplication.Create(rolevm);
            return RedirectToPage("Index");
        }

    }
}
