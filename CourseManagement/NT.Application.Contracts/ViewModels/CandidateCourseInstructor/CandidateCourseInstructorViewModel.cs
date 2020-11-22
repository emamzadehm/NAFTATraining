using NT.CM.Application.Contracts.ViewModels.Candidates;
using NT.CM.Application.Contracts.ViewModels.Companies;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;
using NT.CM.Application.Contracts.ViewModels.Courses;
using NT.CM.Application.Contracts.ViewModels.Instructors;
using System;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor
{
    public class CandidateCourseInstructorViewModel
    {
        public long ID { get; set; }
        public long Course_InstructorID { get; set; }
        public long CourseID { get; set; }
        public long InstructorUserID { get; set; }
        public long CandidateUserID { get; set; }
        public long InstructorID { get; set; }
        public long Location { get; set; }
        public long CandidateID { get; set; }
        public long? CompanyID { get; set; }

        public DateTime SDate { get; set; }
        public DateTime EDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Venue { get; set; }
        public string InstructorName { get; set; }
        public string CourseName { get; set; }
        public string LocationName { get; set; }
        public string Fullname { get; set; }
        public string CompanyName { get; set; }

        public List<CompanyViewModel> CompanyList { get; set; }
        public List<CourseInstructorViewModel> CourseInstructorList { get; set; }
        public List<CourseViewModel> CourseList { get; set; }
        public List<InstructorsViewModel> InstructorList { get; set; }
        public List<CandidateViewModel> CandidateList { get; set; }


    }

}
