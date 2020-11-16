namespace NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor
{
    public class CandidateCourseInstructorViewModel
    {
        public long ID { get; set; }
        public long Course_InstructorID { get;  set; }
        public long CandidateID { get;  set; }
        public string RegistrationDate { get;  set; }
    }
}
