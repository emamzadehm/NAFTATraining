using _01.Framework.Application;
using Microsoft.AspNetCore.Http;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NT.CM.Application.Contracts.ViewModels.Galleries
{
    public class GalleryViewModel
    {
        public long ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public long TypeID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public IFormFile PhotoAddress { get; set; }

        public long? ParentID { get; set; }
        public string TypeName { get; set; }
        public string ParentName { get; set; }
        public List<BaseInfoViewModel> PhotoType { get; set; }
        public List<GalleryViewModel> GalleryList { get; set; }
        public string FileAddress { get; set; }

    }
}
