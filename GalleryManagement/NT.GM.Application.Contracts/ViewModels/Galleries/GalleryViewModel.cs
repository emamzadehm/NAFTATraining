using _01.Framework.Application;
using Microsoft.AspNetCore.Http;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NT.GM.Application.Contracts.ViewModels.Galleries
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
        public long? CourseInstructorId { get; set; }
        public string CourseInstructorName { get; set; }


        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
        public string Slug { get; set; }
        public string CanonicalAddress { get; set; }

        public List<CourseInstructorViewModel> CourseInstructor { get; set; }



    }
}
