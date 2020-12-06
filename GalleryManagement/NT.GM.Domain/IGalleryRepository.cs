using _01.Framework.Domain;
using NT.GM.Application.Contracts.ViewModels.Galleries;
using NT.GM.Domain.GalleryAgg;
using System.Collections.Generic;

namespace NT.GM.Domain
{
    public interface IGalleryRepository : IRepository<long, Gallery>
    {
        List<GalleryViewModel> Search(GalleryViewModel command = null);
        GalleryViewModel GetDetails(long id);
        List<GalleryViewModel> GetAlbums();
        List<GalleryViewModel> GetPhotoByAlbum(long id);
        //IEnumerable<IGrouping<long?, GalleryViewModel>> GetAlbums();
    }
}
