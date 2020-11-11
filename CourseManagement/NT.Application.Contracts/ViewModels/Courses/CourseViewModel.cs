using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Application.Contracts
{
    public class CourseViewModel
    {
        public long ID { get; set; }
        public string CName { get; set; }
        public string Description { get; set; }
        public string? Audience { get; set; }
        public string? DailyPlan { get; set; }
        public long? Cost { get; set; }
        public byte? CourseCatalog { get; set; }
        public long? CourseLevel { get; set; }
        public string? CourseLevelTitle { get; set; }
        public int Duration { get; set; }
        public long CategoryID { get; set; }
        public string CategoryIDTitle { get; set; }
        public bool Status { get; set; }
        public bool IsPrivate { get; set; }

    }
}
