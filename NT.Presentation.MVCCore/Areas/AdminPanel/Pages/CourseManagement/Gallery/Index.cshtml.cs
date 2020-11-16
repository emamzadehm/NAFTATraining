using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using NT.CM.Application.Contracts.ViewModels.Galleries;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.Gallery
{
    public class IndexModel : PageModel
    {
        private readonly IGalleryApplication _igalleryapplication;
        private readonly IBaseInfoApplication _ibaseinfoapplication;
        public GalleryViewModel searchmodelgallery;
        public BaseInfoViewModel searchmodelbaseinfo;
        public SelectList gallerylist;


        public List<GalleryViewModel> candidateVM { get; set; }
        public GalleryViewModel SearchModel { get; set; }

        public IndexModel(IGalleryApplication igalleryapplication, IBaseInfoApplication ibaseinfoapplication)
        {
            _igalleryapplication = igalleryapplication;
            _ibaseinfoapplication = ibaseinfoapplication;
        }

        public void OnGet(GalleryViewModel searchmodel)
        {
            searchmodel.ParentID = 0;
            gallerylist = new SelectList(_igalleryapplication.Search(searchmodel).Where(x=>x.ParentID==null), "ID", "Title");
            candidateVM = _igalleryapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            searchmodelgallery = new GalleryViewModel();
            searchmodelbaseinfo = new BaseInfoViewModel();
            var command = new GalleryViewModel
            {
                PhotoType = _ibaseinfoapplication.Search(searchmodelbaseinfo),
                GalleryList = _igalleryapplication.Search(searchmodelgallery)

            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(GalleryViewModel candidatevm)
        {
            var result = _igalleryapplication.Create(candidatevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var selecteditem = _igalleryapplication.GetBy(id);
            searchmodelgallery = new GalleryViewModel();
            searchmodelbaseinfo = new BaseInfoViewModel();
            selecteditem.PhotoType = _ibaseinfoapplication.Search(searchmodelbaseinfo);
            selecteditem.GalleryList = _igalleryapplication.Search(searchmodelgallery);
            return Partial("./Edit", selecteditem);

        }
        public JsonResult OnPostEdit(GalleryViewModel candidatevm)
        {
            var result = _igalleryapplication.Edit(candidatevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(GalleryViewModel candidatevm)
        {
            _igalleryapplication.Remove(candidatevm.ID);
            return RedirectToPage("Index");
        }

    }
}
