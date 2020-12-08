using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.Candidates;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;
using NT.CM.Application.Contracts.ViewModels.Courses;
using NT.CM.Application.Contracts.ViewModels.Instructors;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor
{
    public class CreateEditCandidateCourseInstructorViewModel
    {
        public long ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        [Range(0, int.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long Course_InstructorID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        [Range(0,int.MaxValue,ErrorMessage =ValidationMessages.IsRequired)]
        public long CandidateID { get; set; }

        public string RegistrationDate { get; set; }
        public List<CandidateViewModel> CandidateList { get; set; }
        public List<CourseInstructorViewModel> CourseInstructorList { get; set; }
        public List<CourseViewModel> CourseList { get; set; }
        public List<InstructorsViewModel> InstructorList { get; set; }

        public string Fullname { get; set; }
        public string InstructorName { get; set; }
        public string CourseName { get; set; }
    }
}
