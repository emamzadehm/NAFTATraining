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

        public GalleryViewModel GetDetails(long id)
        {
            var result = _ntcontext.Tbl_Gallery.Where(x => x.Status == true).Select(listitem => new GalleryViewModel
            {
                ID = listitem.ID,
                Title = listitem.Title,
                TypeID = listitem.TypeID,
                TypeName = listitem.BaseInfo.Title,
                FileAddress = listitem.PhotoAddress,
                ParentID = listitem.ParentID,
                ParentName = listitem.gallery.Title
            }).FirstOrDefault(x=>x.ID==id);
            return result;
        }

        public List<GalleryViewModel> Search(GalleryViewModel command = null)
        {
            var Query = _ntcontext.Tbl_Gallery.Where(x => x.Status == true).Select(listitem => new GalleryViewModel
            {
                ID = listitem.ID,
                Title = listitem.Title,
                TypeID = listitem.TypeID,
                TypeName=listitem.BaseInfo.Title,
                FileAddress=listitem.PhotoAddress,
                ParentID=listitem.ParentID,
                ParentName=listitem.gallery.Title
               
            });
            if (command != null)
            {
                if (command.ParentID == null)
                    Query = Query.Where(x => x.ParentID == null);
                if (command.ID > 0)
                    Query = Query.Where(x => x.ID == command.ID || x.ParentID == command.ID);
                if (!string.IsNullOrWhiteSpace(command.Title))
                    Query = Query.Where(x => x.Title.Contains(command.Title));
            }
            
            return Query.OrderBy(x => x.ID).ToList();
        }
    }
}
