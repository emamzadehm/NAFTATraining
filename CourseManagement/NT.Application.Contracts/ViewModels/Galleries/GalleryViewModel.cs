using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Application.Contracts.ViewModels.Galleries
{
    public class GalleryViewModel
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public long TypeID { get; set; }
        public string PhotoAddress { get; set; }
        public long ParentID { get; set; }
        public string BaseInfoName { get; set; }
    }
}
