using NT.CM.Domain.CourseInstructorAgg;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.CM.Domain.InstructorAgg
{
    public class Instructor : Users
    {
        public string? EducationLevel { get; private set; }
        public string? Resume { get; private set; }
        public ICollection<CourseInstructor> CourseInstructors { get; private set; }

        protected Instructor()
        {
            //Users = new Users();
        }
        public Instructor(string? educationlevel, string? resume)
        {
            EducationLevel = educationlevel;
            Resume = resume;
            CourseInstructors = new List<CourseInstructor>();
        }

        public void Edit(string? educationLevel, string? resume)
        {
            //Users.Edit(firstname, lastname, sex, tel, img, password, idcardimg);
            EducationLevel = educationLevel;
            Resume = resume;
        }
    }
}
