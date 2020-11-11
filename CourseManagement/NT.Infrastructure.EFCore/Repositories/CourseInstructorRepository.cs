using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;
using NT.CM.Domain;
using NT.CM.Domain.CourseInstructorAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class CourseInstructorRepository : BaseRepository<long, CourseInstructor>, ICourseInstructorRepository
    {
        private readonly NTContext _ntcontext;

        public CourseInstructorRepository(NTContext ntcontext) : base(ntcontext)
        {
            _ntcontext = ntcontext;
        }

        public List<CourseInstructorViewModel> Search(CourseInstructorViewModel command)
        {
            var Query = _ntcontext.Tbl_Course_Instructor.Where(x => x.Status == true).Select(listitem => new CourseInstructorViewModel
            {
                ID = listitem.ID,
                CourseID=listitem.CourseID,
                CourseName=listitem.Course.CName,
                Capacity=listitem.Capacity,
                SDate=listitem.SDate,
                EDate=listitem.EDate,
                InstructorID=listitem.InstructorID,
                InstructorName=listitem.Instructor.FirstName + " " + listitem.Instructor.LastName,
                Location=listitem.Location,
                LocationName=listitem.BaseInfo.Title,
                Venue=listitem.Venue
            });
            if (!string.IsNullOrWhiteSpace(command.CourseName))
                Query = Query.Where(x => x.CourseName.Contains(command.CourseName));
            return Query.OrderBy(x => x.ID).ToList();
        }
    }
}
