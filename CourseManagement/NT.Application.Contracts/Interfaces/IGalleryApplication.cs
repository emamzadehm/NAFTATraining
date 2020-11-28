using _01.Framework.Application;
using Microsoft.AspNetCore.Http;
using NT.CM.Application.Contracts.ViewModels.Galleries;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts.Interfaces
{
    public interface IGalleryApplication
    {
        OperationResult Create(GalleryViewModel command, List<IFormFile> files);
        OperationResult Edit(GalleryViewModel command);
        OperationResult Remove(long id);
        GalleryViewModel GetBy(long id);
        List<GalleryViewModel> Search(GalleryViewModel searchmodel = null);
    }
}
