using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.UsersManagement.Users
{
    public class IndexModel : PageModel
    {
        public IUserApplication _iuserapplication;
        public List<UsersViewModel> userVM { get; set; }
        public UsersViewModel SearchModel { get; set; }
        public IndexModel(IUserApplication iuserapplication)
        {
            _iuserapplication = iuserapplication;
        }

        public void OnGet(UsersViewModel searchmodel)
        {
            userVM = _iuserapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new UsersViewModel());
        }
        public JsonResult OnPostCreate(UsersViewModel uservm)
        {
            var result = _iuserapplication.Create(uservm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _iuserapplication.GetBy(id);
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(UsersViewModel uservm)
        {
            var result = _iuserapplication.Edit(uservm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(UsersViewModel uservm)
        {
            _iuserapplication.Remove(uservm.ID);
            return RedirectToPage("Index");
        }
    }
}
