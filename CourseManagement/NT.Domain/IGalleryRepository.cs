using _01.Framework.Domain;
using NT.CM.Application.Contracts.ViewModels.Galleries;
using NT.CM.Domain.GalleryAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Domain
{
    public interface IGalleryRepository : IRepository<long, Gallery>
    {
        List<GalleryViewModel> Search(GalleryViewModel command);
    }
}
