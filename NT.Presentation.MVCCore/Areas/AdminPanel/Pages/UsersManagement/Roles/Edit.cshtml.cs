using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.UsersManagement.Roles
{
    public class EditModel : PageModel
    {
        public RolesViewModel RoleVM { get; set; }
        public IRolesApplication _irolesApplication;
        public IPermissionsApplication _ipermissionsApplication;
        public IRolePermissionApplication _irolepermissionsApplication;
        public IPermissionTypes _ipermissionTypes;
        public List<PermissionsViewModel> modulesList;
        //public List<PermissionsViewModel> permissionsList;
        //public Dictionary<long?, List<PermissionsViewModel>> Allpermissions;
        public List<SelectListItem> Permissions = new List<SelectListItem>();

        public EditModel(IRolesApplication irolesApplication, IPermissionsApplication ipermissionsApplication,
            IRolePermissionApplication irolepermissionsApplication, IPermissionTypes ipermissionTypes)
        {
            _irolesApplication = irolesApplication;
            _ipermissionsApplication = ipermissionsApplication;
            _irolepermissionsApplication = irolepermissionsApplication;
            _ipermissionTypes = ipermissionTypes;
        }

        public void OnGet(long id)
        {
            modulesList = _ipermissionsApplication.GetAllModules();
            Permissions = GetPermissionsByRole(id);

            //var AllPermissions = _ipermissionsApplication.GetPermissionsByModule(id);

            ////foreach (var item in RoleVM.PermissionsList)
            ////{
            ////    var group = new SelectListGroup() { Name = item.PermissionParentName };
            ////    var items = new SelectListItem()
            ////    {
            ////        Value = item.PermissionID.ToString(),
            ////        Text = item.PermissionName.ToString(),
            ////        Group = group
            ////    };
            //foreach (var (key, value) in AllPermissions)
            //{

            //    var parentTitle = _ipermissionsApplication.GetDetails(key).Title;
            //    var group = new SelectListGroup() { Name = parentTitle };
            //    foreach (var per in value)
            //    {
            //        var item = new SelectListItem()
            //        {
            //            Value = per.ID.ToString(),
            //            Text = per.Title,
            //            Group = group
            //        };
            //        if (RoleVM.PermissionsList.Any(x => x.PermissionID == per.ID))
            //            item.Selected = true;
            //        Permissions.Add(item);
            //    }

            //}
        }

        public List<SelectListItem> GetPermissionsByRole(long id)
        {
            RoleVM = _irolesApplication.GetDetails(id);
            Permissions = new List<SelectListItem>();
            var AllPermissions = _ipermissionsApplication.GetPermissionsByModule();
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
                    if (RoleVM.PermissionsList.Any(x => x.PermissionID == per.ID))
                        item.Selected = true;


                    Permissions.Add(item);
                }

            }
            return Permissions;
        }


        public IActionResult OnPost(RolesViewModel rolevm)
        {
            _irolesApplication.Edit(rolevm);
            return RedirectToPage("Index");
        }
    }
}
