using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Application.Contracts.ViewModels;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.SiteManagement.About
{
    public class IndexModel : PageModel
    {

        private readonly ISite_BaseApplication _isite_baseapplication;
        private readonly ISite_AboutApplication _isiteabout_application;

        public List<Site_AboutViewModel> site_aboutVM { get; set; }
        public Site_AboutViewModel SearchModel { get; set; }
        public Site_BaseViewModel searchmodelsite_base { get; set; }

        public IndexModel(ISite_BaseApplication isite_baseapplication, ISite_AboutApplication isiteabout_application)
        {
            _isite_baseapplication = isite_baseapplication;
            _isiteabout_application = isiteabout_application;
        }

        public void OnGet(Site_AboutViewModel searchmodel)
        {
            site_aboutVM = _isiteabout_application.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            searchmodelsite_base = new Site_BaseViewModel();
            var command = new Site_AboutViewModel
            {
                Site_BaseList = _isite_baseapplication.Search(searchmodelsite_base)
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(Site_AboutViewModel site_aboutvm)
        {
            var result = _isiteabout_application.Create(site_aboutvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _isiteabout_application.GetBy(id);
            searchmodelsite_base = new Site_BaseViewModel();
            selecteditem.Site_BaseList = _isite_baseapplication.Search(searchmodelsite_base);

            return Partial("./Edit", selecteditem);

        }
        public JsonResult OnPostEdit(Site_AboutViewModel site_aboutvm)
        {
            var result = _isiteabout_application.Edit(site_aboutvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(Site_AboutViewModel site_aboutvm)
        {
            _isiteabout_application.Remove(site_aboutvm.Id);
            return RedirectToPage("Index");
        }

    }
}
