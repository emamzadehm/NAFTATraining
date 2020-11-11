using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.Galleries;
using NT.CM.Domain;
using NT.CM.Domain.GalleryAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class GalleryRepository : BaseRepository<long, Gallery> , IGalleryRepository
    {
        private readonly NTContext _ntcontext;
        public GalleryRepository(NTContext ntcontext):base(ntcontext)
        {
            _ntcontext = ntcontext;
        }

        public List<GalleryViewModel> Search(GalleryViewModel command)
        {
            var Query = _ntcontext.Tbl_Gallery.Where(x => x.Status == true).Select(listitem => new GalleryViewModel
            {
                ID = listitem.ID,
                Title = listitem.Title,
                TypeID = listitem.TypeID,
                BaseInfoName=listitem.BaseInfo.Title,
                PhotoAddress=listitem.PhotoAddress,
                ParentID=listitem.ParentID
            });
            if (!string.IsNullOrWhiteSpace(command.Title))
                Query = Query.Where(x => x.Title.Contains(command.Title));
            return Query.OrderBy(x => x.ID).ToList();
        }
    }
}
