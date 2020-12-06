using _01.Framework.Application;
using Microsoft.AspNetCore.Http;
using NT.GM.Application.Contracts.ViewModels.Galleries;
using System.Collections.Generic;

namespace NT.GM.Application.Contracts.Interfaces
{
    public interface IGalleryApplication
    {
        OperationResult Create(GalleryViewModel command, List<IFormFile> files);
        OperationResult Edit(GalleryViewModel command);
        OperationResult Remove(long id);
        GalleryViewModel GetBy(long id);
        List<GalleryViewModel> GetAlbums();
        List<GalleryViewModel> Search(GalleryViewModel searchmodel = null);
        List<GalleryViewModel> GetPhotoByAlbum(long id);
    }
}
