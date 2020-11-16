using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.Companies;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.Company
{
    public class IndexModel : PageModel
    {
        //public List<SelectListItem> TypeIDModel { get; set; }

        private readonly ICompanyApplication _icompanyapplication;
        public List<CompanyViewModel> companyVM { get; set; }
        public CompanyViewModel SearchModel { get; set; }

        public IndexModel(ICompanyApplication icompanyapplication)
        {
            _icompanyapplication = icompanyapplication;
        }

        public void OnGet(CompanyViewModel searchmodel)
        {
            companyVM = _icompanyapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CompanyViewModel());
        }
        public JsonResult OnPostCreate(CompanyViewModel companyvm)
        {
            var result = _icompanyapplication.Create(companyvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _icompanyapplication.GetBy(id);
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(CompanyViewModel companyvm)
        {
            var result = _icompanyapplication.Edit(companyvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(CompanyViewModel companyvm)
        {
            _icompanyapplication.Remove(companyvm.ID);
            return RedirectToPage("Index");
        }
    }
}
