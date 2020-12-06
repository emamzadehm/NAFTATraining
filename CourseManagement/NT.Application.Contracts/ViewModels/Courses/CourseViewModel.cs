using _01.Framework.Application;
using Microsoft.AspNetCore.Http;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NT.CM.Application.Contracts.ViewModels.Courses
{
    public class CourseViewModel
    {
        public long ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string CName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string Audience { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string DailyPlan { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public long Cost { get; set; }

        public IFormFile CourseCatalog { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public long CourseLevel { get; set; }
        public string CourseLevelTitle { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public int Duration { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryID { get; set; }
        public string CategoryIDTitle { get; set; }
        public bool Status { get; set; }
        public List<BaseInfoViewModel> Category { get; set; }
        public List<BaseInfoViewModel> Level { get; set; }
        public string FileAddress { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
        public string Slug { get; set; }
        public string CanonicalAddress { get; set; }


    }
}
