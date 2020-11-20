using _01.Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor
{
    public class CandidateCourseInstructorViewModel
    {
        public long ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public long Course_InstructorID { get;  set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]

        public long CandidateID { get;  set; }
        public string RegistrationDate { get;  set; }
    }
}
