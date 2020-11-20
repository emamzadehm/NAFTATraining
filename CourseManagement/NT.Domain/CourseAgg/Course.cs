using _01.Framework.Domain;
using Domain.BaseInfoAgg;
using NT.CM.Domain.CourseInstructorAgg;
using System.Collections.Generic;

namespace NT.CM.Domain.CourseAgg
{
    public class Course : DomainBase
    {
        public string CName { get; protected set; }
        public string Description { get; protected set; }
        public string Audience { get; protected set; }
        public string DailyPlan { get; protected set; }
        public long Cost { get; protected set; }
        public string CourseCatalog { get; protected set; }
        public long CourseLevel { get; protected set; }
        public BaseInfo BaseInfoCourseLevel { get; private set; }
        public int Duration { get; protected set; }
        public bool IsPrivate { get; private set; }
        public long CategoryID { get; protected set; }
        public BaseInfo BaseInfoCategory { get; private set; }
        public ICollection<CourseInstructor> CourseInstructors { get; set; }

        protected Course()
        {

        }
        public Course(string cname, string description,string audience, string dailyplan, long cost, string coursecatalog, long courselevel, int duration, long categoryid, bool isprivate)
        {
            //courseValidator.CourseExist(cname);
            //courseValidator.Validation(cname,);
            CName = cname;
            Description = description;
            Audience = audience;
            DailyPlan = dailyplan;
            Cost = cost;
            CourseCatalog = coursecatalog;
            CourseLevel = courselevel;
            Duration = duration;
            CategoryID = categoryid;
            CourseInstructors = new List<CourseInstructor>();
            IsPrivate = isprivate;
        }

        public void Edit(string cname, string description, string audience, string dailyplan, long cost, string coursecatalog, long courselevel, int duration, long categoryid, bool isprivate)
        {
            CName = cname;
            Description = description;
            Audience = audience;
            DailyPlan = dailyplan;
            Cost = cost;
            CourseCatalog = coursecatalog;
            CourseLevel = courselevel;
            Duration = duration;
            CategoryID = categoryid;
            IsPrivate = isprivate;
        }
    }
}
