using _01.Framework.Domain;
using System.Collections.Generic;

namespace NT.GM.Domain.GalleryAgg
{
    public class Gallery: DomainBase
    {
        public string Title { get; private set; }
        public long TypeID { get; private set; }
        public string PhotoAddress { get; private set; }
        public long? ParentID { get; private set; }
        public Gallery gallery { get; private set; }
        public ICollection<Gallery> Galleries { get; private set; }

        public string MetaDescription { get; private set; }
        public string Keywords { get; private set; }
        public string Slug { get; private set; }
        public string CanonicalAddress { get; private set; }
        //public BaseInfo BaseInfo { get; private set; }
        //public CourseInstructor courseInstructor { get; private set; }
        public long? CourseInstructorId { get; private set; }

        protected Gallery()
        {

        }

        public Gallery(string title, long typeID, string photoAddress, long? parentID, long? courseInstructorId,
            string metaDescription, string keywords, string slug, string canonicalAddress)
        {
            Title = title;
            TypeID = typeID;
            PhotoAddress = photoAddress;
            ParentID = parentID;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
            CanonicalAddress = canonicalAddress;
            CourseInstructorId = courseInstructorId;
        }

        public void Edit(string title, long typeID, string photoAddress, long? parentID, long? courseInstructorId,
            string metaDescription, string keywords, string slug, string canonicalAddress)
        {
            Title = title;
            TypeID = typeID;
            if (!string.IsNullOrWhiteSpace(photoAddress))
                PhotoAddress = photoAddress;
            PhotoAddress = photoAddress;
            ParentID = parentID;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
            CanonicalAddress = canonicalAddress;
            CourseInstructorId = courseInstructorId;
            
        }
    }
}
