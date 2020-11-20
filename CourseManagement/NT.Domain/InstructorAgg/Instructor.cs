using _01.Framework.Domain;
using NT.CM.Domain.CourseInstructorAgg;
using System.Collections.Generic;

namespace NT.CM.Domain.InstructorAgg
{
    public class Instructor : DomainBase
    {
        public long UserId { get; private set; }
        public string EducationLevel { get; private set; }
        public string Resume { get; private set; }
        public ICollection<CourseInstructor> CourseInstructors { get; private set; }

        protected Instructor()
        {
            //Users = new Users();
        }
        public Instructor(string educationlevel, string resume, long userid)
        {
            EducationLevel = educationlevel;
            Resume = resume;
            CourseInstructors = new List<CourseInstructor>();
            UserId = userid;
        }

        public void Edit(string educationLevel, string resume)
        {
            EducationLevel = educationLevel;
            Resume = resume;
        }
    }
}
