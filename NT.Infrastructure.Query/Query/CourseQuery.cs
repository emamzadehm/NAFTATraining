using Microsoft.EntityFrameworkCore;
using NT.CM.Infrastructure.EFCore;
using NT.Infrastructure.Query.Interface;
using NT.Infrastructure.Query.ViewModel;
using System.Collections.Generic;
using System.Linq;



namespace NT.Infrastructure.Query.Query
{
    public class CourseQuery : ICourseQuery
    {
        private readonly NTContext _ntcontext;
        public CourseQuery(NTContext ntcontext)
        {
            _ntcontext = ntcontext;
        }
        public List<CourseQueryView> CourseList()
        {
            return _ntcontext.Tbl_Course.Select(x => new CourseQueryView { 
            ID=x.ID,
            CName=x.CName,
            Description=x.Description,
            Audience=x.Audience,
            DailyPlan=x.DailyPlan,
            Cost = x.Cost,
            CourseCatalog=x.CourseCatalog,
            CourseLevel=x.CourseLevel,
            Duration=x.Duration,
            CategoryID=x.CategoryID,
            Status=x.Status,
            //IsPrivate=x.IsPrivate
            })
                .Where(x=>x.Status==true)
                .Where(x => x.IsPrivate == false)
                .ToList();
        }

    }
}
