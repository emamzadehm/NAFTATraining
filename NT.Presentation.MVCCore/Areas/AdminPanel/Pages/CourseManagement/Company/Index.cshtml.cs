using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.Company
{
    public class IndexModel : PageModel
    {
        //public List<SelectListItem> TypeIDModel { get; set; }

        private readonly ICompanyApplication _icompanyapplication;
        private readonly IBaseInfoApplication _ibaseinfoapplication;
        public List<CompanyViewModel> companyVM { get; set; }
        public CompanyViewModel SearchModel { get; set; }
        public IndexModel(ICompanyApplication icompanyapplication, IBaseInfoApplication ibaseinfoapplication)
        {
            _icompanyapplication = icompanyapplication;
            _ibaseinfoapplication = ibaseinfoapplication;
        }

        public void OnGet(CompanyViewModel searchmodel)
        {
            companyVM = _icompanyapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            var companyvm = new CompanyViewModel {
                CompanyType = _ibaseinfoapplication.GetAll()
            };
            return Partial("./Create", companyvm);
        }
        public JsonResult OnPostCreate(CompanyViewModel companyvm)
        {
            var result = _icompanyapplication.Create(companyvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _icompanyapplication.GetBy(id);
            selecteditem.CompanyType = _ibaseinfoapplication.GetAll();
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(CompanyViewModel companyvm)
        {
            var result = _icompanyapplication.Edit(companyvm);
            return new JsonResult(result);
        }
        public JsonResult OnPostRemove(CompanyViewModel companyvm)
        {
            var result = _icompanyapplication.Remove(companyvm.ID);
            return new JsonResult(result);
        }
    }
}
