using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.UsersManagement.UsersRoles
{
    public class IndexModel : PageModel
    {
        public IUsersRolesApplication _iusersrolesApplication;
        public IUserApplication _iuserApplication;
        public IRolesApplication _irolesApplication;
        public List<UsersRolesViewModel> usersrolesVM { get; set; }
        public UsersRolesViewModel SearchModel { get; set; }
        public SelectList userslist;
        public SelectList roleslist;

        public IndexModel(IUsersRolesApplication iusersrolesApplication, IUserApplication iuserApplication,
            IRolesApplication irolesApplication)
        {
            _iusersrolesApplication = iusersrolesApplication;
            _iuserApplication = iuserApplication;
            _irolesApplication = irolesApplication;
        }

        public void OnGet(UsersRolesViewModel searchmodel)
        {
            userslist = new SelectList(_iuserApplication.Search(), "ID", "Fullname");
            roleslist = new SelectList(_irolesApplication.Search(), "ID", "RoleName");

            usersrolesVM = _iusersrolesApplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new UsersRolesViewModel
            {
                UsersList = _iuserApplication.Search(),
                RolesList = _irolesApplication.Search()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(UsersRolesViewModel rolevm)
        {
            var result = _iusersrolesApplication.Create(rolevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var selecteditem = _iusersrolesApplication.GetDetails(id);
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(UsersRolesViewModel rolevm)
        {
            var result = _iusersrolesApplication.Edit(rolevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(UsersRolesViewModel rolevm)
        {
            _iusersrolesApplication.Remove(rolevm.ID);
            return RedirectToPage("Index");
        }
    }
}
