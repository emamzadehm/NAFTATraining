using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.BaseInfo
{
    public class IndexModel : PageModel
    {
        public IBaseInfoApplication _ibaseinfoapplication;
        public List<BaseInfoViewModel> baseinfoVM { get; set; }
        public BaseInfoViewModel SearchModel { get; set; }
        public SelectList BaseInfoTypes;

        public IndexModel(IBaseInfoApplication ibaseinfoapplication)
        {
            _ibaseinfoapplication = ibaseinfoapplication;
        }

        public void OnGet(BaseInfoViewModel searchmodel)
        {
            BaseInfoTypes = new SelectList(_ibaseinfoapplication.GetAllTypes(),"ID","Title");
                
            baseinfoVM = _ibaseinfoapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new BaseInfoViewModel
            {
                Types = _ibaseinfoapplication.Search(),
                Parent=_ibaseinfoapplication.Search()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(BaseInfoViewModel baseinfovm)
        {
            var result = _ibaseinfoapplication.Create(baseinfovm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _ibaseinfoapplication.GetBy(id);
            selecteditem.Parent = _ibaseinfoapplication.Search();
            selecteditem.Types = _ibaseinfoapplication.Search();
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(BaseInfoViewModel baseinfovm)
        {
            var result = _ibaseinfoapplication.Edit(baseinfovm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(BaseInfoViewModel baseinfovm)
        {
            _ibaseinfoapplication.Remove(baseinfovm.ID);
            return RedirectToPage("Index");
        }

    }
}
