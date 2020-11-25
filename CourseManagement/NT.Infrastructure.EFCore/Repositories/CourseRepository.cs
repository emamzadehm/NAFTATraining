using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.Courses;
using NT.CM.Domain;
using NT.CM.Domain.CourseAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class CourseRepository : BaseRepository<long, Course>, ICourseRepository
    {
        private readonly NTContext _ntcontext;
        public CourseRepository(NTContext ntcontext) : base (ntcontext)
        {
            _ntcontext = ntcontext;
        }

        public List<CourseViewModel> Search(CourseViewModel command = null)
        {
            var Query = _ntcontext.Tbl_Course.Where(x => x.Status == true).Select(listitem => new CourseViewModel
            {
                ID = listitem.ID,
                CName=listitem.CName,
                CategoryID=listitem.CategoryID,
                CategoryIDTitle=listitem.BaseInfoCategory.Title,
                Audience=listitem.Audience,
                Cost = listitem.Cost,
                FileAddress=listitem.CourseCatalog,
                CourseLevel=listitem.CourseLevel,
                CourseLevelTitle=listitem.BaseInfoCourseLevel.Title,
                DailyPlan=listitem.DailyPlan,
                Description=listitem.Description,
                Duration=listitem.Duration,
                IsPrivate=listitem.IsPrivate,
                Status = listitem.Status
            });
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.Description))
                    Query = Query.Where(x => x.Description.Contains(command.Description));
                if (command.ID > 0)
                    Query = Query.Where(x => x.ID == command.ID);
            }
            
            return Query.OrderBy(x => x.ID).ToList();
        }

        public CourseViewModel GetDetails(long id)
        {
            return _ntcontext.Tbl_Course.Where(x => x.Status == true).Select(listitem => new CourseViewModel
            {
                ID = listitem.ID,
                CName = listitem.CName,
                CategoryID = listitem.CategoryID,
                CategoryIDTitle = listitem.BaseInfoCategory.Title,
                Audience = listitem.Audience,
                Cost = listitem.Cost,
                FileAddress = listitem.CourseCatalog,
                CourseLevel = listitem.CourseLevel,
                CourseLevelTitle = listitem.BaseInfoCourseLevel.Title,
                DailyPlan = listitem.DailyPlan,
                Description = listitem.Description,
                Duration = listitem.Duration,
                IsPrivate = listitem.IsPrivate,
                Status = listitem.Status
            }).FirstOrDefault(x => x.ID == id);
        }
    }
}
