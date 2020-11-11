using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.BaseInfo
{
    public class IndexModel : PageModel
    {
        public IBaseInfoApplication _ibaseinfoapplication;
        public List<BaseInfoViewModel> baseinfoVM { get; set; }
        public BaseInfoViewModel SearchModel { get; set; }
        public IndexModel(IBaseInfoApplication ibaseinfoapplication)
        {
            _ibaseinfoapplication = ibaseinfoapplication;
        }

        public void OnGet(BaseInfoViewModel searchmodel)
        {
            baseinfoVM = _ibaseinfoapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new BaseInfoViewModel
            {
                Type = _ibaseinfoapplication.GetAll(),
                Parent=_ibaseinfoapplication.GetAll()
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
            selecteditem.Parent = _ibaseinfoapplication.GetAll();
            selecteditem.Type = _ibaseinfoapplication.GetAll();
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(BaseInfoViewModel baseinfovm)
        {
            var result = _ibaseinfoapplication.Edit(baseinfovm);
            return new JsonResult(result);
        }
        public JsonResult OnPostRemove(BaseInfoViewModel baseinfovm)
        {
            var result = _ibaseinfoapplication.Remove(baseinfovm.ID);
            return new JsonResult(result);
        }

    }
}
