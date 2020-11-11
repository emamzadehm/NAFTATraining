using _01.Framework.Domain;
using NT.CM.Domain.CandidateAgg;
using NT.CM.Domain.CourseCandidateInstructorDetailsAgg;
using NT.CM.Domain.CourseInstructorAgg;
using System;
using System.Collections.Generic;

namespace NT.CM.Domain.CandidateCourseInstructorAgg
{
    public class CandidateCourseInstructor: DomainBase
    {
        public long Course_InstructorID { get; private set; }
        public long CandidateID { get; private set; }
        public string RegistrationDate { get; private set; }
        public Candidate Candidates { get; private set; }
        public CourseInstructor CourseInstructors { get; private set; }
        public ICollection<CourseCandidateInstructorDetails> CourseCandidateInstructorDetailss { get; private set; }

        protected CandidateCourseInstructor()
        {

        }
        public CandidateCourseInstructor(long course_instructorid, long candidateid)
        {
            Course_InstructorID = course_instructorid;
            CandidateID = candidateid;
            RegistrationDate = DateTime.Now.ToString();
            CourseCandidateInstructorDetailss = new List<CourseCandidateInstructorDetails>();
        }
        public void Edit(long course_instructorid, long candidateid)
        {
            Course_InstructorID = course_instructorid;
            CandidateID = candidateid;
            //CourseCandidateInstructorDetailss.edit(typeid, value, documentimg, cci_id);
        }

        //public void Edit(int courseid, string fullname, string email, string tel, string organization)
        //{
        //    CourseID = courseid;
        //    Candidates.Edit(fullname, email, tel, organization);
        //}
    }
}
