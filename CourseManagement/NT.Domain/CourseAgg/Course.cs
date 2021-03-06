﻿using _01.Framework.Domain;
using NT.CM.Domain.BaseInfoAgg;
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
        public string MetaDescription { get; private set; }
        public string Keywords { get; private set; }
        public string Slug { get; private set; }
        public string CanonicalAddress { get; private set; }
        public BaseInfo BaseInfoCourseLevel { get; private set; }
        public int Duration { get; protected set; }
        public long CategoryID { get; protected set; }
        public BaseInfo BaseInfoCategory { get; private set; }
        public ICollection<CourseInstructor> CourseInstructors { get; set; }

        protected Course()
        {

        }
        public Course(string cname, string description,string audience, string dailyplan, long cost, string coursecatalog,
            long courselevel, int duration, long categoryid, string metaDescription, string keywords, string slug,
            string canonicalAddress)
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
            CourseInstructors = new List<CourseInstructor>();
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
            CanonicalAddress = canonicalAddress;
        }

        public void Edit(string cname, string description, string audience, string dailyplan, long cost, string coursecatalog,
            long courselevel, int duration, long categoryid, string metaDescription, string keywords, string slug,
            string canonicalAddress)
        {
            CName = cname;
            Description = description;
            Audience = audience;
            DailyPlan = dailyplan;
            Cost = cost;
            if (!string.IsNullOrWhiteSpace(coursecatalog))
                CourseCatalog = coursecatalog;
            CourseLevel = courselevel;
            Duration = duration;
            CategoryID = categoryid;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
            CanonicalAddress = canonicalAddress;
        }
    }
}
