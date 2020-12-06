using _01.Framework.Infrastructure.EFCore;
using NT.GM.Application.Contracts.ViewModels.Galleries;
using NT.GM.Domain;
using NT.GM.Domain.GalleryAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.GM.Infrastructure.EFCore.Repositories
{
    public class GalleryRepository : BaseRepository<long, Gallery> , IGalleryRepository
    {
        private readonly NTGMContext _ntcontext;
        public GalleryRepository(NTGMContext ntcontext):base(ntcontext)
        {
            _ntcontext = ntcontext;
        }

        public List<GalleryViewModel> GetAlbums()
        {
            var Query = _ntcontext.Tbl_Gallery
                .Where(x => x.Status == true)
                .Where(x=>x.ParentID == null)
                .Select(listitem => new GalleryViewModel
            {
                ID = listitem.ID,
                Title = listitem.Title,
                TypeID = listitem.TypeID,
                FileAddress = listitem.PhotoAddress,
                ParentID = listitem.ParentID,
                ParentName = listitem.gallery.Title

            });
            

            return Query.OrderBy(x => x.ID).ToList();
        }

        public GalleryViewModel GetDetails(long id)
        {
            var result = _ntcontext.Tbl_Gallery.Where(x => x.Status == true).Select(listitem => new GalleryViewModel
            {
                ID = listitem.ID,
                Title = listitem.Title,
                TypeID = listitem.TypeID,
                //TypeName = listitem.BaseInfo.Title,
                FileAddress = listitem.PhotoAddress,
                ParentID = listitem.ParentID,
                ParentName = listitem.gallery.Title,
                CourseInstructorId = listitem.CourseInstructorId
                //CourseInstructorName=listitem.courseInstructor.Course.CName + " - " +
                  //                   listitem.courseInstructor.SDate
            }).FirstOrDefault(x=>x.ID==id);
            return result;
        }

        public List<GalleryViewModel> GetPhotoByAlbum(long id)
        {
            {
                var Query = _ntcontext.Tbl_Gallery
                    .Where(x => x.Status == true)
                    .Where(x => x.ParentID == id)
                    .Select(listitem => new GalleryViewModel
                    {
                        ID = listitem.ID,
                        Title = listitem.Title,
                        TypeID = listitem.TypeID,
                        FileAddress = listitem.PhotoAddress,
                        ParentID = listitem.ParentID,
                        ParentName = listitem.gallery.Title

                    });


                return Query.OrderBy(x => x.ID).ToList();
            }
        }

        public List<GalleryViewModel> Search(GalleryViewModel command = null)
        {
            var Query = _ntcontext.Tbl_Gallery.Where(x => x.Status == true).Select(listitem => new GalleryViewModel
            {
                ID = listitem.ID,
                Title = listitem.Title,
                TypeID = listitem.TypeID,
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
