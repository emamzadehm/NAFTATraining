using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Application.Contracts.ViewModels;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.SiteManagement.Base
{
    public class IndexModel : PageModel
    {

        private readonly ISite_BaseApplication _isite_baseapplication;

        public List<Site_BaseViewModel> site_baseVM { get; set; }
        public Site_BaseViewModel SearchModel { get; set; }

        public IndexModel(ISite_BaseApplication isite_baseapplication)
        {
            _isite_baseapplication = isite_baseapplication;
        }

        public void OnGet(Site_BaseViewModel searchmodel)
        {
            site_baseVM = _isite_baseapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new Site_BaseViewModel());
        }
        public JsonResult OnPostCreate(Site_BaseViewModel site_basevm)
        {
            var result = _isite_baseapplication.Create(site_basevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _isite_baseapplication.GetBy(id);
            return Partial("./Edit", selecteditem);

        }
        public JsonResult OnPostEdit(Site_BaseViewModel site_basevm)
        {
            var result = _isite_baseapplication.Edit(site_basevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(Site_BaseViewModel site_basevm)
        {
            _isite_baseapplication.Remove(site_basevm.Id);
            return RedirectToPage("Index");
        }

    }
}
