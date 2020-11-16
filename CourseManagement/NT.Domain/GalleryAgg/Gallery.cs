using _01.Framework.Domain;
using Domain.BaseInfoAgg;
using System.Collections.Generic;

namespace NT.CM.Domain.GalleryAgg
{
    public class Gallery: DomainBase
    {
        public string Title { get; private set; }
        public long TypeID { get; private set; }
        public string PhotoAddress { get; private set; }
        public long? ParentID { get; private set; }
        public Gallery gallery { get; private set; }
        public ICollection<Gallery> Galleries { get; private set; }
        public BaseInfo BaseInfo { get; private set; }

        protected Gallery()
        {

        }
        public Gallery(string title, long typeid, string photoaddress, long? parentid)
        {
            Title = title;
            TypeID = typeid;
            PhotoAddress = photoaddress;
            Galleries = new List<Gallery>();
            ParentID = parentid;
        }
        public void Edit(string title, long typeid, string photoaddress, long? parentid)
        {
            Title = title;
            TypeID = typeid;
            PhotoAddress = photoaddress;
            ParentID = parentid;
        }
    }
}
