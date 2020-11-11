using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts;
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

        public List<CourseViewModel> Search(CourseViewModel command)
        {
            var Query = _ntcontext.Tbl_Course.Where(x => x.Status == true).Select(listitem => new CourseViewModel
            {
                ID = listitem.ID,
                CName=listitem.CName,
                CategoryID=listitem.CategoryID,
                CategoryIDTitle=listitem.BaseInfoCategory.Title,
                Audience=listitem.Audience,
                Cost = listitem.Cost,
                CourseCatalog=listitem.CourseCatalog,
                CourseLevel=listitem.CourseLevel,
                CourseLevelTitle=listitem.BaseInfoCourseLevel.Title,
                DailyPlan=listitem.DailyPlan,
                Description=listitem.Description,
                Duration=listitem.Duration,
                IsPrivate=listitem.IsPrivate,
                Status = listitem.Status
            });
            if (!string.IsNullOrWhiteSpace(command.Description))
                Query = Query.Where(x => x.Description.Contains(command.Description));
            return Query.OrderBy(x => x.ID).ToList();
        }




        //public override List<Course> GetAll()
        //{
        //    return _ntcontext.Tbl_Course
        //                .Include(x=>x.CategoryBI)
        //                .Include(x=>x.CourseLevelsBI)
        //                .ToList();
        //}

        //public Course GetBy(int id)
        //{
        //    return _ntcontext.Tbl_Course.FirstOrDefault(x => x.ID == id);
        //}

        //public void Remove(Course command)
        //{
        //    _ntcontext.Tbl_Course.Remove(command);
        //   Save();
        //}


        //public void Create(Course command)
        //{
        //    _ntcontext.Tbl_Course.Add(command);
        //    Save();
        //}

        //public void Save()
        //{
        //    _ntcontext.SaveChanges();
        //}

        //public bool Exists(string CourseName)
        //{
        //    return _ntcontext.Tbl_Course.Any(x => x.CName == CourseName);
        //}
    }
}
