using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts.ViewModels.Galleries
{
    public class GalleryViewModel
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public long TypeID { get; set; }
        public string PhotoAddress { get; set; }
        public long? ParentID { get; set; }
        public string TypeName { get; set; }
        public string ParentName { get; set; }
        public List<BaseInfoViewModel> PhotoType { get; set; }
        public List<GalleryViewModel> GalleryList { get; set; }

    }
}
