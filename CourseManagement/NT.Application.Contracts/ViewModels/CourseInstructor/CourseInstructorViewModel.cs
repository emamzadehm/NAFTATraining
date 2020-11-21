using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using NT.CM.Application.Contracts.ViewModels.Courses;
using NT.CM.Application.Contracts.ViewModels.Instructors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NT.CM.Application.Contracts.ViewModels.CourseInstructor
{
    public class CourseInstructorViewModel
    {
        public long ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public long CourseID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public long InstructorID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public DateTime SDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public DateTime EDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public int Capacity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string Venue { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public long Location { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public string LocationName { get; set; }
        public List<BaseInfoViewModel> LocationList { get; set; }
        public List<InstructorsViewModel> InstructorList { get; set; }
        public List<CourseViewModel> CourseList { get; set; }

        public string CourseInfo { get; set; }
    }
}