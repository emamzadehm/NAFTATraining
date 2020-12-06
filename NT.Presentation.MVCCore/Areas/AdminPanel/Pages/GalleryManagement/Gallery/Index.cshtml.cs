using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NT.GM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using NT.GM.Application.Contracts.ViewModels.Galleries;
using NT.CM.Application.Contracts.Interfaces;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.GalleryManagement.Gallery
{
    public class IndexModel : PageModel
    {
        private readonly IGalleryApplication _igalleryapplication;
        private readonly IBaseInfoApplication _ibaseinfoapplication;
        private readonly ICourseInstructorApplication _icourseinstructorapplication;

        public GalleryViewModel searchmodelgallery;
        public BaseInfoViewModel searchmodelbaseinfo;
        public SelectList gallerylist;

        public List<GalleryViewModel> galleryVM { get; set; }
        public GalleryViewModel SearchModel { get; set; }

        public IndexModel(IGalleryApplication igalleryapplication, IBaseInfoApplication ibaseinfoapplication,
            ICourseInstructorApplication icourseinstructorapplication)
        {
            _igalleryapplication = igalleryapplication;
            _ibaseinfoapplication = ibaseinfoapplication;
            _icourseinstructorapplication = icourseinstructorapplication;
        }

        public void OnGet(GalleryViewModel searchmodel)
        {
            gallerylist = new SelectList(_igalleryapplication.GetAlbums(), "ID", "Title");

            if (searchmodel.ID > 0 || !string.IsNullOrWhiteSpace(searchmodel.Title))
            {
                galleryVM = _igalleryapplication.Search(searchmodel);
            }
            else
            {
                galleryVM = _igalleryapplication.GetAlbums();
            }
        }
        public IActionResult OnGetCreate()
        {
            var command = new GalleryViewModel
            {
                PhotoType = _ibaseinfoapplication.Search(),
                GalleryList = _igalleryapplication.Search(),
                CourseInstructor = _icourseinstructorapplication.Search()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(GalleryViewModel galleryvm, List<IFormFile> photoAddress)
        {
            var result = _igalleryapplication.Create(galleryvm, photoAddress);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var selecteditem = _igalleryapplication.GetBy(id);
            selecteditem.PhotoType = _ibaseinfoapplication.Search();
            selecteditem.GalleryList = _igalleryapplication.Search();
            selecteditem.CourseInstructor = _icourseinstructorapplication.Search();

            return Partial("./Edit", selecteditem);

        }
        public JsonResult OnPostEdit(GalleryViewModel galleryvm)
        {
            var result = _igalleryapplication.Edit(galleryvm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            _igalleryapplication.Remove(id);
            return RedirectToPage("Index");
        }
        public IActionResult OnGetView(long id)
        {
            var selecteditem = _igalleryapplication.GetPhotoByAlbum(id);
            return Partial("./View", selecteditem);

        }

    }
}
