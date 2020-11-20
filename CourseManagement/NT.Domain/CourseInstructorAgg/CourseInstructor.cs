using _01.Framework.Domain;
using Domain.BaseInfoAgg;
using NT.CM.Domain.CandidateCourseInstructorAgg;
using NT.CM.Domain.CourseAgg;
using NT.CM.Domain.InstructorAgg;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NT.CM.Domain.CourseInstructorAgg
{
    public class CourseInstructor : DomainBase
    {
        public long CourseID { get; private set; }
        public long InstructorID { get; private set; }
        public DateTime SDate { get; private set; }
        public DateTime EDate { get; private set; }
        public int Capacity { get; private set; }
        public string Venue { get; private set; }
        public long Location { get; protected set; }
        public Course Course { get; private set; }
        public Instructor Instructor { get; private set; }
        public BaseInfo BaseInfo { get; private set; }
        public ICollection<CandidateCourseInstructor> CandidateCourseInstructors { get; private set; }


        public CourseInstructor()
        {

        }
        public CourseInstructor(long courseid, long instructorid, DateTime sdate, DateTime edate, int capacity, string venue, long location)
        {
            CourseID = courseid;
            InstructorID = instructorid;
            SDate = sdate;
            EDate = edate;
            Capacity = capacity;
            Venue = venue;
            Location = location;
            CandidateCourseInstructors = new List<CandidateCourseInstructor>();
        }
        public void Edit(long courseid, long instructorid, DateTime sdate, DateTime edate, int capacity, string venue, long location)
        {
            CourseID = courseid;
            InstructorID = instructorid;
            SDate = sdate;
            EDate = edate;
            Capacity = capacity;
            Venue = venue;
            Location = location;
        }
    }
}
