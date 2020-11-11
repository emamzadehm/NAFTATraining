using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Application.Contracts.ViewModels.CourseInstructor
{
    public class CourseInstructorViewModel
    {
        public long ID { get; set; }
        public long CourseID { get; set; }
        public long InstructorID { get; set; }
        public string SDate { get; set; }
        public string EDate { get; set; }
        public int Capacity { get; set; }
        public string Venue { get; set; }
        public long Location { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public string LocationName { get; set; }
    }
}
