using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.Galleries;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Application.Contracts.Interfaces
{
    public interface IGalleryApplication
    {
        OperationResult Create(GalleryViewModel command);
        OperationResult Edit(GalleryViewModel command);
        OperationResult Remove(long id);
        GalleryViewModel GetBy(long id);
        List<GalleryViewModel> Search(GalleryViewModel searchmodel);
    }
}
